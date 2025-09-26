using System.Linq.Expressions;
using Expressions.Models;

namespace Expressions.Operators.String;

public class EqualsOperator
{
    public Expression Instance { get; set; }
    public string Value { get; set; }

    public Expression GetExpression()
    {
        return Expression.Equal(Instance, Expression.Constant(Value));
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

public class InOperator
{
    public Expression Instance { get; set; }
    public PList<string> Values { get; set; }

    public Expression GetExpression()
    {
        var methodInfo = typeof(PList<string>).GetMethod(
            nameof(PList<string>.Contains),
            [typeof(string)]
        );
        return Expression.Call(Expression.Constant(Values), methodInfo, Instance);
    }
}
