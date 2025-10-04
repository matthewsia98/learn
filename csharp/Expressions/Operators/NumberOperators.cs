using System.Linq.Expressions;

namespace Expressions.Operators.Number;

public class EqualsOperator
{
    public Expression Instance { get; set; }
    public object Value { get; set; }

    public Expression GetExpression()
    {
        return Expression.Equal(Instance, Expression.Constant(Value, Value.GetType()));
    }
}

public class GreaterThanOperator
{
    public Expression Instance { get; set; }
    public object Value { get; set; }

    public Expression GetExpression()
    {
        return Expression.GreaterThan(Instance, Expression.Constant(Value, Value.GetType()));
    }
}

public class GreaterThanOrEqualOperator
{
    public Expression Instance { get; set; }
    public object Value { get; set; }

    public Expression GetExpression()
    {
        return Expression.GreaterThanOrEqual(Instance, Expression.Constant(Value, Value.GetType()));
    }
}

public class LessThanOperator
{
    public Expression Instance { get; set; }
    public object Value { get; set; }

    public Expression GetExpression()
    {
        return Expression.LessThan(Instance, Expression.Constant(Value, Value.GetType()));
    }
}

public class LessThanOrEqualOperator
{
    public Expression Instance { get; set; }
    public object Value { get; set; }

    public Expression GetExpression()
    {
        return Expression.LessThanOrEqual(Instance, Expression.Constant(Value, Value.GetType()));
    }
}

public class BetweenOperator
{
    public Expression Instance { get; set; }
    public object LowerBound { get; set; }
    public object UpperBound { get; set; }

    public Expression GetExpression()
    {
        return Expression.AndAlso(
            Expression.GreaterThanOrEqual(
                Instance,
                Expression.Constant(LowerBound, LowerBound.GetType())
            ),
            Expression.LessThanOrEqual(
                Instance,
                Expression.Constant(UpperBound, UpperBound.GetType())
            )
        );
    }
}
