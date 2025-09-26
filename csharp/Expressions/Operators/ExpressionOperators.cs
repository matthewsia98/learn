using System.Linq.Expressions;

namespace Expressions.Operators;

public static class ExpressionOperators
{
    public static Expression Not(Expression Instance)
    {
        return Expression.Not(Instance);
    }
}
