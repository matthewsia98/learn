using System;
using System.Text.Json;
using System.Linq.Expressions;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		var person = new Person
		{
			Name = "Matt",
			Age = 18,
			Weight = 61,
			Interests = ["Hello", "World"],
			Parent = new Person
			{
				Name = "Dan",
				Age = 50,
				Weight = 73,
			},
		};
		Console.WriteLine(JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true }));
		
		var es = "Name contains M";
		var parts = es.Split(" ", 3);
		//Console.WriteLine(string.Join(", ", parts));
		
		var paramExpr = Expression.Parameter(typeof(Person), "p");
		
		var propName = parts[0];
		var propNameParts = propName.Split(".");
		//Console.WriteLine(string.Join(", ", propNameParts));
		
		Type propType;
		Expression propExpr;
		if (propNameParts.Length == 1)
		{
			propExpr = Expression.Property(paramExpr, propName);
			propType = typeof(Person).GetProperty(propName).PropertyType;
		}
		else
		{
			Expression partExpr = paramExpr;
			var partType = typeof(Person);
			foreach (var part in propNameParts)
			{
				partExpr = Expression.Property(partExpr, part);
				partType = partType.GetProperty(part).PropertyType;
			}
			propExpr = partExpr;
			propType = partType;
		}
		//Console.WriteLine(propExpr);
		//Console.WriteLine(propType.Name);
		
		var opName = parts[1];
		
		var constantValueString = parts[2];
		object constantValue;
		var valueType = propType;
		if (valueType.IsGenericType)
		{
			valueType = propType.GetGenericArguments()[0];
		}
		constantValue = valueType switch
		{
				Type t when t == typeof(int) => int.Parse(constantValueString),
				Type t when t == typeof(string) => constantValueString,
				_ => throw new NotImplementedException()
		};
		//Console.WriteLine(constantValue.GetType());
		var constantExpr = Expression.Constant(constantValue, valueType);

		Expression binaryExpr = opName switch
		{
				"contains" => Expression.Call(propExpr, propType.GetMethod("Contains", new[] { valueType }), constantExpr),
				"==" => Expression.Equal(propExpr, constantExpr),
				">" => Expression.GreaterThan(propExpr, constantExpr),
				">=" => Expression.GreaterThanOrEqual(propExpr, constantExpr),
				"<" => Expression.LessThan(propExpr, constantExpr),
				"<=" => Expression.LessThanOrEqual(propExpr, constantExpr),
				_ => throw new NotImplementedException(),
		};
	
		var expr = Expression.Lambda<Func<Person, bool>>(binaryExpr, paramExpr);
		Console.WriteLine(expr);
		
		var p = expr.Compile();
		
		var result = p(person);
		Console.WriteLine(result);
	}
}

class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
	public double Weight { get; set; }
	public List<string> Interests { get; set; }
	public Person Parent { get; set; }
}