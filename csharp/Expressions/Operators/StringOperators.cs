using System.Linq.Expressions;

namespace Expressions.Operators;

public class EqualsOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }

    public Expression GetExpression()
    {
        return Expression.Equal(Instance, Expression.Constant(Value));
    }
}

public class NotEqualsOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }
    public Expression GetExpression()
    {
        return new NotOperator
        {
            Instance = new EqualsOperator
            {
                Instance = Instance,
                Value = Value
            }.GetExpression()
        }.GetExpression();
    }
}


public class ContainsOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }

    public Expression GetExpression()
    {
        var methodInfo = typeof(string).GetMethod(nameof(string.Contains), [typeof(string)]);
        return Expression.Call(Instance, methodInfo, Expression.Constant(Value));
    }
}


public class NotContainsOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }
    public Expression GetExpression()
    {
        return new NotOperator
        {
            Instance = new ContainsOperator
            {
                Instance = Instance,
                Value = Value
            }.GetExpression()
        }.GetExpression();
    }
}

public class StartsWithOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }

    public Expression GetExpression()
    {
        var methodInfo = typeof(string).GetMethod(nameof(string.StartsWith), [typeof(string)]);
        return Expression.Call(Instance, methodInfo, Expression.Constant(Value));
    }
}

public class NotStartsWithOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }
    public Expression GetExpression()
    {
        return new NotOperator
        {
            Instance = new StartsWithOperator
            {
                Instance = Instance,
                Value = Value
            }.GetExpression()
        }.GetExpression();
    }
}

public class EndsWithOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }

    public Expression GetExpression()
    {
        var methodInfo = typeof(string).GetMethod(nameof(string.EndsWith), [typeof(string)]);
        return Expression.Call(Instance, methodInfo, Expression.Constant(Value));
    }
}

public class NotEndsWithOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }
    public Expression GetExpression()
    {
        return new NotOperator
        {
            Instance = new EndsWithOperator
            {
                Instance = Instance,
                Value = Value
            }.GetExpression()
        }.GetExpression();
    }
}

public class InOperator
{
    public Expression Instance { get; set; }
    public ICollection<string> Values { get; set; }

    public Expression GetExpression()
    {
        var methodInfo = typeof(ICollection<string>).GetMethod(nameof(ICollection<string>.Contains), [typeof(string)]);
        return Expression.Call(Expression.Constant(Values), methodInfo, Instance);
    }
}

public class NotInOperator
{
    public Expression Instance { get; set; }
    public ICollection<string> Values { get; set; }
    public Expression GetExpression()
    {
        return new NotOperator
        {
            Instance = new InOperator
            {
                Instance = Instance,
                Values = Values
            }.GetExpression()
        }.GetExpression();
    }
}
