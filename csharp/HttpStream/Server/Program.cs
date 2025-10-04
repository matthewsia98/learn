var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/chars", GetChars);
app.MapGet("/people", GetPeople);

app.Run();

async IAsyncEnumerable<char> GetChars()
{
    var s = "Hello, World!";
    foreach (var c in s)
    {
        await Task.Delay(1000);
        yield return c;
    }
}

async IAsyncEnumerable<Person> GetPeople()
{
    List<Person> people = [
        new("John", "Doe"),
        new("Jane", "Doe"),
        new("Jack", "Doe"),
        new("Jill", "Doe"),
        new("Jim", "Doe"),
    ];

    foreach (var person in people)
    {
        await Task.Delay(1000);
        yield return person;
    }
}


record Person(string FirstName, string LastName);
