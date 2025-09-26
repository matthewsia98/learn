using System.Linq.Expressions;
using Expressions.Models;

namespace Expressions.Examples;

public static class Examples
{
    public static void Run(Person p, Expression<Func<Person, object>> selector)
    {
        var type = selector.Body switch
        {
            MemberExpression me => me.Type,
            UnaryExpression ue => ue.Operand.Type,
            _ => throw new NotImplementedException()
        };

        if (type == typeof(string))
        {
            StringExamples.Run(p, selector);
        }
        else if (type == typeof(int) || type == typeof(double))
        {
            NumberExamples.Run(p, selector);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public static void Run(
        Person p,
        Expression<Func<Person, object>> selector,
        Expression predicate
    )
    {
        var type = selector.Body switch
        {
            MemberExpression me => me.Type,
            UnaryExpression ue => ue.Operand.Type,
            _ => throw new NotImplementedException()
        };

        if (type == typeof(string))
        {
            StringExamples.Run(p, selector);
        }
        else if (type == typeof(int) || type == typeof(double))
        {
            NumberExamples.Run(p, selector);
        }
        else if (
            typeof(System.Collections.IList).IsAssignableFrom(type)
            || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        )
        {
            ListExamples.Run(p, selector, predicate);
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
