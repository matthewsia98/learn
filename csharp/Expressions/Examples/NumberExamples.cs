using System.Linq.Expressions;
using Expressions.Models;
using Expressions.Operators;
using Expressions.Operators.Number;

namespace Expressions.Examples;

public class NumberExamples
{
    public static void Run(Person p, Expression<Func<Person, object>> selector)
    {
        Console.WriteLine(new string('=', nameof(NumberExamples).Length));
        Console.WriteLine(nameof(NumberExamples));
        Console.WriteLine(new string('=', nameof(NumberExamples).Length));

        var paramExpr = selector.Parameters.First();

        var unaryExpr = (UnaryExpression)selector.Body;
        var propExpr = (MemberExpression)unaryExpr.Operand;
        var propType = propExpr.Type;
        var f0 = selector.Compile();
        var propValue = Convert.ChangeType(f0(p), propType);
        Console.WriteLine($"{propExpr}: {propValue}");

        var equalsTrueExpr = new EqualsOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(propValue, propType)
        }.GetExpression();
        var f1 = Expression.Lambda<Func<Person, bool>>(equalsTrueExpr, paramExpr).Compile();
        var r1 = f1(p);
        Console.WriteLine($"{equalsTrueExpr}: {r1}");

        var notEqualsFalseExpr = ExpressionOperators.Not(equalsTrueExpr);
        var f4 = Expression.Lambda<Func<Person, bool>>(notEqualsFalseExpr, paramExpr).Compile();
        var r4 = f4(p);
        Console.WriteLine($"{notEqualsFalseExpr}: {r4}");

        var equalsFalseExpr = new EqualsOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(Convert.ToDecimal(propValue) + 1, propType)
        }.GetExpression();
        var f2 = Expression.Lambda<Func<Person, bool>>(equalsFalseExpr, paramExpr).Compile();
        var r2 = f2(p);
        Console.WriteLine($"{equalsFalseExpr}: {r2}");

        var greaterThanTrueExpr = new GreaterThanOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(Convert.ToDecimal(propValue) - 1, propType)
        }.GetExpression();
        var f5 = Expression.Lambda<Func<Person, bool>>(greaterThanTrueExpr, paramExpr).Compile();
        var r5 = f5(p);
        Console.WriteLine($"{greaterThanTrueExpr}: {r5}");

        var greaterThanFalseExpr = new GreaterThanOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(Convert.ToDecimal(propValue) + 1, propType)
        }.GetExpression();
        var f6 = Expression.Lambda<Func<Person, bool>>(greaterThanFalseExpr, paramExpr).Compile();
        var r6 = f6(p);
        Console.WriteLine($"{greaterThanFalseExpr}: {r6}");

        var greaterThanOrEqualTrueExpr = new GreaterThanOrEqualOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(propValue, propType)
        }.GetExpression();
        var f7 = Expression
            .Lambda<Func<Person, bool>>(greaterThanOrEqualTrueExpr, paramExpr)
            .Compile();
        var r7 = f7(p);
        Console.WriteLine($"{greaterThanOrEqualTrueExpr}: {r7}");

        var greaterThanOrEqualFalseExpr = new GreaterThanOrEqualOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(Convert.ToDecimal(propValue) + 1, propType)
        }.GetExpression();
        var f8 = Expression
            .Lambda<Func<Person, bool>>(greaterThanOrEqualFalseExpr, paramExpr)
            .Compile();
        var r8 = f8(p);
        Console.WriteLine($"{greaterThanOrEqualFalseExpr}: {r8}");

        var lessThanTrueExpr = new LessThanOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(Convert.ToDecimal(propValue) + 1, propType)
        }.GetExpression();
        var f9 = Expression.Lambda<Func<Person, bool>>(lessThanTrueExpr, paramExpr).Compile();
        var r9 = f9(p);
        Console.WriteLine($"{lessThanTrueExpr}: {r9}");

        var lessThanFalseExpr = new LessThanOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(Convert.ToDecimal(propValue) - 1, propType)
        }.GetExpression();
        var f10 = Expression.Lambda<Func<Person, bool>>(lessThanFalseExpr, paramExpr).Compile();
        var r10 = f10(p);
        Console.WriteLine($"{lessThanFalseExpr}: {r10}");

        var lessThanOrEqualTrueExpr = new LessThanOrEqualOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(propValue, propType)
        }.GetExpression();
        var f11 = Expression
            .Lambda<Func<Person, bool>>(lessThanOrEqualTrueExpr, paramExpr)
            .Compile();
        var r11 = f11(p);
        Console.WriteLine($"{lessThanOrEqualTrueExpr}: {r11}");

        var lessThanOrEqualFalseExpr = new LessThanOrEqualOperator
        {
            Instance = propExpr,
            Value = Convert.ChangeType(Convert.ToDecimal(propValue) - 1, propType)
        }.GetExpression();
        var f12 = Expression
            .Lambda<Func<Person, bool>>(lessThanOrEqualFalseExpr, paramExpr)
            .Compile();
        var r12 = f12(p);
        Console.WriteLine($"{lessThanOrEqualFalseExpr}: {r12}");

        var betweenTrueExpr = new BetweenOperator
        {
            Instance = propExpr,
            LowerBound = Convert.ChangeType(Convert.ToDecimal(propValue) - 1, propType),
            UpperBound = Convert.ChangeType(Convert.ToDecimal(propValue) + 1, propType)
        }.GetExpression();
        var f13 = Expression.Lambda<Func<Person, bool>>(betweenTrueExpr, paramExpr).Compile();
        var r13 = f13(p);
        Console.WriteLine($"{betweenTrueExpr}: {r13}");

        var betweenFalseExpr = new BetweenOperator
        {
            Instance = propExpr,
            LowerBound = Convert.ChangeType(Convert.ToDecimal(propValue) + 1, propType),
            UpperBound = Convert.ChangeType(Convert.ToDecimal(propValue) + 2, propType)
        }.GetExpression();
        var f14 = Expression.Lambda<Func<Person, bool>>(betweenFalseExpr, paramExpr).Compile();
        var r14 = f14(p);
        Console.WriteLine($"{betweenFalseExpr}: {r14}");
    }
}
