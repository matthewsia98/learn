using System.Linq.Expressions;
using Expressions.Models;
using Expressions.Operators;
using Expressions.Operators.String;

namespace Expressions.Examples;

public static class StringExamples
{
    //public static void Run(Person p)
    public static void Run(Person p, Expression<Func<Person, object>> selector)
    {
        Console.WriteLine(new string('=', nameof(StringExamples).Length));
        Console.WriteLine(nameof(StringExamples));
        Console.WriteLine(new string('=', nameof(StringExamples).Length));

        var paramExpr = selector.Parameters.First();

        var propExpr = (MemberExpression)selector.Body;
        var f0 = Expression.Lambda<Func<Person, string>>(propExpr, paramExpr).Compile();
        var propValue = f0(p);
        Console.WriteLine($"{propExpr}: {propValue}");

        var equalsTrueExpr = new EqualsOperator
        {
            Instance = propExpr,
            Value = propValue
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
            Value = $"not {propValue}"
        }.GetExpression();
        var f2 = Expression.Lambda<Func<Person, bool>>(equalsFalseExpr, paramExpr).Compile();
        var r2 = f2(p);
        Console.WriteLine($"{equalsFalseExpr}: {r2}");

        var containsTrueExpr = new ContainsOperator
        {
            Instance = propExpr,
            Value = propValue.Substring(1, 2)
        }.GetExpression();
        var f5 = Expression.Lambda<Func<Person, bool>>(containsTrueExpr, paramExpr).Compile();
        var r5 = f5(p);
        Console.WriteLine($"{containsTrueExpr}: {r5}");

        var containsFalseExpr = new ContainsOperator
        {
            Instance = propExpr,
            Value = "zzz"
        }.GetExpression();
        var f6 = Expression.Lambda<Func<Person, bool>>(containsFalseExpr, paramExpr).Compile();
        var r6 = f6(p);
        Console.WriteLine($"{containsFalseExpr}: {r6}");

        var startsWithTrueExpr = new StartsWithOperator
        {
            Instance = propExpr,
            Value = propValue.Substring(0, 1)
        }.GetExpression();
        var f7 = Expression.Lambda<Func<Person, bool>>(startsWithTrueExpr, paramExpr).Compile();
        var r7 = f7(p);
        Console.WriteLine($"{startsWithTrueExpr}: {r7}");

        var startsWithFalseExpr = new StartsWithOperator
        {
            Instance = propExpr,
            Value = "z"
        }.GetExpression();
        var f8 = Expression.Lambda<Func<Person, bool>>(startsWithFalseExpr, paramExpr).Compile();
        var r8 = f8(p);
        Console.WriteLine($"{startsWithFalseExpr}: {r8}");

        var endsWithTrueExpr = new EndsWithOperator
        {
            Instance = propExpr,
            Value = propValue.Substring(propValue.Length - 1, 1)
        }.GetExpression();
        var f11 = Expression.Lambda<Func<Person, bool>>(endsWithTrueExpr, paramExpr).Compile();
        var r11 = f11(p);
        Console.WriteLine($"{endsWithTrueExpr}: {r11}");

        var endsWithFalseExpr = new EndsWithOperator
        {
            Instance = propExpr,
            Value = "z"
        }.GetExpression();
        var f12 = Expression.Lambda<Func<Person, bool>>(endsWithFalseExpr, paramExpr).Compile();
        var r12 = f12(p);
        Console.WriteLine($"{endsWithFalseExpr}: {r12}");

        var inTrueList = new PList<string> { "not " + propValue, propValue };
        var inTrueExpr = new InOperator
        {
            Instance = propExpr,
            Values = inTrueList
        }.GetExpression();
        var f9 = Expression.Lambda<Func<Person, bool>>(inTrueExpr, paramExpr).Compile();
        var r9 = f9(p);
        Console.WriteLine($"{inTrueExpr}: {r9}");

        var inFalseList = new PList<string> { "not " + propValue, "also not " + propValue };
        var inFalseExpr = new InOperator
        {
            Instance = propExpr,
            Values = inFalseList
        }.GetExpression();
        var f10 = Expression.Lambda<Func<Person, bool>>(inFalseExpr, paramExpr).Compile();
        var r10 = f10(p);
        Console.WriteLine($"{inFalseExpr}: {r10}");

        Console.WriteLine();
    }
}
