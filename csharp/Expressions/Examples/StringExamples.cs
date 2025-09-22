using System.Linq.Expressions;

using Expressions.Models;
using Expressions.Operators;

namespace Expressions.Examples;

public static class StringExamples
{
    //public static void Run(Person p)
    public static void Run(Person p, Expression<Func<Person, string>> selector)
    {
        Console.WriteLine(new string('=', nameof(StringExamples).Length));
        Console.WriteLine(nameof(StringExamples));
        Console.WriteLine(new string('=', nameof(StringExamples).Length));

        var paramExpr = selector.Parameters.First();

        var propExpr = (MemberExpression)selector.Body;
        var f0 = Expression.Lambda<Func<Person, string>>(propExpr, paramExpr).Compile();
        var r0 = f0(p);
        Console.WriteLine($"{propExpr}: {r0}");

        var equalsTrueExpr = new EqualsOperator { Instance = propExpr, Value = p.Name }.GetExpression();
        var f1 = Expression.Lambda<Func<Person, bool>>(equalsTrueExpr, paramExpr).Compile();
        var r1 = f1(p);
        Console.WriteLine($"{equalsTrueExpr}: {r1}");

        var notEqualsFalseExpr = new NotEqualsOperator { Instance = propExpr, Value = p.Name }.GetExpression();
        var f4 = Expression.Lambda<Func<Person, bool>>(notEqualsFalseExpr, paramExpr).Compile();
        var r4 = f4(p);
        Console.WriteLine($"{notEqualsFalseExpr}: {r4}");

        var equalsFalseExpr = new EqualsOperator { Instance = propExpr, Value = $"not {p.Name}" }.GetExpression();
        var f2 = Expression.Lambda<Func<Person, bool>>(equalsFalseExpr, paramExpr).Compile();
        var r2 = f2(p);
        Console.WriteLine($"{equalsFalseExpr}: {r2}");

        var containsTrueExpr = new ContainsOperator { Instance = propExpr, Value = p.Name.Substring(1, 2) }.GetExpression();
        var f5 = Expression.Lambda<Func<Person, bool>>(containsTrueExpr, paramExpr).Compile();
        var r5 = f5(p);
        Console.WriteLine($"{containsTrueExpr}: {r5}");

        var containsFalseExpr = new ContainsOperator { Instance = propExpr, Value = "zzz" }.GetExpression();
        var f6 = Expression.Lambda<Func<Person, bool>>(containsFalseExpr, paramExpr).Compile();
        var r6 = f6(p);
        Console.WriteLine($"{containsFalseExpr}: {r6}");

        var startsWithTrueExpr = new StartsWithOperator { Instance = propExpr, Value = p.Name.Substring(0, 1) }.GetExpression();
        var f7 = Expression.Lambda<Func<Person, bool>>(startsWithTrueExpr, paramExpr).Compile();
        var r7 = f7(p);
        Console.WriteLine($"{startsWithTrueExpr}: {r7}");

        var startsWithFalseExpr = new StartsWithOperator { Instance = propExpr, Value = "z" }.GetExpression();
        var f8 = Expression.Lambda<Func<Person, bool>>(startsWithFalseExpr, paramExpr).Compile();
        var r8 = f8(p);
        Console.WriteLine($"{startsWithFalseExpr}: {r8}");

        var endsWithTrueExpr = new EndsWithOperator { Instance = propExpr, Value = p.Name.Substring(p.Name.Length - 1, 1) }.GetExpression();
        var f11 = Expression.Lambda<Func<Person, bool>>(endsWithTrueExpr, paramExpr).Compile();
        var r11 = f11(p);
        Console.WriteLine($"{endsWithTrueExpr}: {r11}");

        var endsWithFalseExpr = new EndsWithOperator { Instance = propExpr, Value = "z" }.GetExpression();
        var f12 = Expression.Lambda<Func<Person, bool>>(endsWithFalseExpr, paramExpr).Compile();
        var r12 = f12(p);
        Console.WriteLine($"{endsWithFalseExpr}: {r12}");

        var inTrueList = new List<string> { "not " + p.Name, p.Name };
        var inTrueExpr = new InOperator { Instance = propExpr, Values = inTrueList }.GetExpression();
        var f9 = Expression.Lambda<Func<Person, bool>>(inTrueExpr, paramExpr).Compile();
        var r9 = f9(p);
        Console.WriteLine($"[{string.Join(", ", inTrueList)}] {inTrueExpr}: {r9}");

        var inFalseList = new List<string> { "not " + p.Name, "also not " + p.Name };
        var inFalseExpr = new InOperator { Instance = propExpr, Values = inFalseList }.GetExpression();
        var f10 = Expression.Lambda<Func<Person, bool>>(inFalseExpr, paramExpr).Compile();
        var r10 = f10(p);
        Console.WriteLine($"[{string.Join(", ", inFalseList)}] {inFalseExpr}: {r10}");

        Console.WriteLine();
    }
}