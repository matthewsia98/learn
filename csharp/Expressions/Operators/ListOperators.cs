using System.Linq.Expressions;

namespace Expressions.Operators.List;

public class ContainsOperator
{
    public Expression Instance { get; set; }
    public object Value { get; set; }

    public Expression GetExpression()
    {
        var elementType = Value.GetType();

        var method = typeof(ICollection<>)
            .MakeGenericType(elementType)
            .GetMethod(nameof(ICollection<object>.Contains), [elementType]);

        // Build the expression to call .Contains(Value) on Instance
        return Expression.Call(Instance, method, Expression.Constant(Value, elementType));
    }
}

public class AnyOperator
{
    public Expression Instance { get; set; }
    public Expression Predicate { get; set; }

    public Expression GetExpression()
    {
        var elementType = Instance.Type.GetGenericArguments()[0];
        var method = typeof(Enumerable)
            .GetMethods()
            .First(m => m.Name == nameof(Enumerable.Any) && m.GetParameters().Length == 2)
            .MakeGenericMethod(elementType);

        return Expression.Call(method, Instance, Predicate);
    }
}

public class AllOperator
{
    public Expression Instance { get; set; }
    public Expression Predicate { get; set; }

    public Expression GetExpression()
    {
        var elementType = Instance.Type.GetGenericArguments()[0];
        var method = typeof(Enumerable)
            .GetMethods()
            .First(m => m.Name == nameof(Enumerable.All) && m.GetParameters().Length == 2)
            .MakeGenericMethod(elementType);

        return Expression.Call(method, Instance, Predicate);
    }
}
