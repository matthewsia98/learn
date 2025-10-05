using System.Security.Claims;
using System.Text;
using System.Text.Json;

using Microsoft.AspNetCore.Authentication;

using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication("Custom")
    .AddScheme<AuthenticationSchemeOptions, AuthHandler>("Custom", options => { });
builder.Services.AddAuthorization();

builder.Services.AddSingleton<Runtime>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", Login);
app.MapGet("/logout", Logout);
app.MapGet("/user", GetUser);
app.MapGet("/chars", GetChars);
app.MapGet("/words", GetWords);
app.MapGet("/people", GetPeople);
app.MapGet("/people-json", GetPeopleJson);

app.Run();

IResult Login(string name, Runtime runtime)
{
    runtime.User = name;
    return Results.Redirect("/user");
}

IResult Logout(Runtime runtime)
{
    runtime.User = null;
    return Results.Redirect("/user");
}

string GetUser(IHttpContextAccessor httpContextAccessor)
{
    return httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "Not logged in";
}

//[Authorize]
async IAsyncEnumerable<char> GetChars(IHttpContextAccessor httpContextAccessor)
{
    var user = GetUser(httpContextAccessor);
    var s = $"Hello, {user}!";
    foreach (var c in s)
    {
        await Task.Delay(1000);
        yield return c;
    }
}

async IAsyncEnumerable<string> GetWords()
{
    var words = new List<string> { "Hello", "from", "the", "other", "side", "of", "the", "streaming", "world", "!" };
    foreach (var word in words)
    {
        await Task.Delay(1000);
        yield return word;
    }
}

//[Authorize]
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


//[Authorize]
async Task GetPeopleJson(IHttpContextAccessor httpContextAccessor)
{
    List<Person> people = [
        new("John", "Doe"),
        new("Jane", "Doe"),
        new("Jack", "Doe"),
        new("Jill", "Doe"),
        new("Jim", "Doe"),
    ];

    var response = httpContextAccessor.HttpContext.Response;
    response.ContentType = "application/json";

    await response.StartAsync();

    await using var stream = response.Body;
    await stream.WriteAsync(Encoding.UTF8.GetBytes("["));

    for (var i = 0; i < people.Count; i ++)
    {
        await JsonSerializer.SerializeAsync(stream, people[i]);
        if (i < people.Count - 1)
        {
            await stream.WriteAsync(Encoding.UTF8.GetBytes(","));
        }
        await stream.FlushAsync();
        await Task.Delay(1000);
    }

    await stream.WriteAsync(Encoding.UTF8.GetBytes("]"));
    await stream.FlushAsync();
}


record Person(string FirstName, string LastName);
