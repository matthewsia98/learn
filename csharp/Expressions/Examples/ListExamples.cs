using System.Linq.Expressions;
using Expressions.Models;
using Expressions.Operators.List;

namespace Expressions.Examples;

public static class ListExamples
{
    public static void Run(
        Person p,
        Expression<Func<Person, object>> selector,
        Expression predicate
    )
    {
        Console.WriteLine(new string('=', nameof(ListExamples).Length));
        Console.WriteLine(nameof(ListExamples));
        Console.WriteLine(new string('=', nameof(ListExamples).Length));

        var paramExpr = selector.Parameters.First();

        var propExpr = (MemberExpression)selector.Body;
        var propType = propExpr.Type;
        var f0 = selector.Compile();
        var propValue = f0(p);
        Console.WriteLine($"{propExpr}: {propValue}");

        var itemType = propType.GetGenericArguments().First();
        var firstMethod = typeof(Enumerable)
            .GetMethods(
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public
            )
            .First(m => m.Name == "First" && m.GetParameters().Length == 1 && m.IsGenericMethod)
            .MakeGenericMethod(itemType);
        var firstItem = firstMethod.Invoke(null, new object[] { propValue });
        Console.WriteLine($"First Item: {firstItem}");

        var containsTrueExpr = new ContainsOperator
        {
            Instance = propExpr,
            Value = firstItem
        }.GetExpression();
        var f1 = Expression.Lambda<Func<Person, bool>>(containsTrueExpr, paramExpr).Compile();
        var r1 = f1(p);
        Console.WriteLine($"{containsTrueExpr}: {r1}");

        var itemParamExpr = Expression.Parameter(itemType, "x");
        //var predicate = Expression.Lambda(
        //    Expression.Equal(itemParamExpr, Expression.Constant(firstItem, itemType)),
        //    itemParamExpr
        //);

        var anyTrueExpr = new AnyOperator
        {
            Instance = propExpr,
            Predicate = predicate
        }.GetExpression();
        var f2 = Expression.Lambda<Func<Person, bool>>(anyTrueExpr, paramExpr).Compile();
        var r2 = f2(p);
        Console.WriteLine($"{anyTrueExpr}: {r2}");

        var allFalseExpr = new AllOperator
        {
            Instance = propExpr,
            Predicate = predicate
        }.GetExpression();
        var f3 = Expression.Lambda<Func<Person, bool>>(allFalseExpr, paramExpr).Compile();
        var r3 = f3(p);
        Console.WriteLine($"{allFalseExpr}: {r3}");
    }
}
