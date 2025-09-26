using System.Linq.Expressions;
using Expressions.Models;

namespace Expressions.Operators;

public static class ExpressionOperators
{
    public static Expression Not(Expression Instance)
    {
        return Expression.Not(Instance);
    }

    public static Expression And(PList<Expression> Instances)
    {
        return Instances.Aggregate((acc, next) => Expression.AndAlso(acc, next));
    }

    public static Expression Or(PList<Expression> Instances)
    {
        return Instances.Aggregate((acc, next) => Expression.OrElse(acc, next));
    }
}
