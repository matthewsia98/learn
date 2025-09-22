using Expressions.Examples;
using Expressions.Models;

var p = new Person
{
    Name = "matt",
    Height = 180,
    Weight = 75.5,
    BirthDate = new DateTime(1990, 1, 1),
    Hobbies = ["reading", "coding"],
    Mother = new Person { Name = "susan" },
    Father = new Person { Name = "john" },
    Children =
    [
        new Person { Name = "alice" },
        new Person { Name = "bob" }
    ]
};

StringExamples.Run(p, p => p.Name);
StringExamples.Run(p, p => p.Mother.Name);
