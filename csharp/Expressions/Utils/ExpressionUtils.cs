using System.Linq.Expressions;

namespace Expressions.Utils;

public static class ExpressionUtils
{
    public static Expression GetNestedProperty(ParameterExpression paramExpr, string propertyPath)
    {
        var parts = propertyPath.Split(".");

        Expression result = paramExpr;
        foreach (var part in parts)
        {
            result = Expression.Property(result, part);
        }

        return result;
    }
}
