using System.Linq.Expressions;

namespace Expressions.Operators;

public class NotOperator
{
    public Expression Instance { get; set; }
    public Expression GetExpression()
    {
        return Expression.Not(Instance);
    }
}
