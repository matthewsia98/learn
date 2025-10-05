using System.Text.Json;

var httpClient = new HttpClient
{
    BaseAddress = new("https://localhost:7182"),
};

await GetChars();
await GetWords();
await GetPeople();
await GetPeopleJson();


async Task GetChars()
{
    Console.WriteLine("Getting chars");
    var response = await httpClient.GetAsync("/chars", HttpCompletionOption.ResponseHeadersRead);
    var stream = await response.Content.ReadAsStreamAsync();

    //var stream = await httpClient.GetStreamAsync("/chars");

    using var reader = new StreamReader(stream);
    var chunkNumber = 0;
    while (!reader.EndOfStream)
    {
        var buffer = new char[1024];
        var charsRead = await reader.ReadAsync(buffer);
        var chunkContent = new string(buffer, 0, charsRead);
        Console.WriteLine($"Chunk {chunkNumber} | Read {charsRead} bytes | {chunkContent}");
        chunkNumber++;
    }
    Console.WriteLine();
}


async Task GetWords()
{
    Console.WriteLine("Getting words");

    var response = await httpClient.GetAsync("/words", HttpCompletionOption.ResponseHeadersRead);
    var stream = await response.Content.ReadAsStreamAsync();

    //var stream = await httpClient.GetStreamAsync("/chars");

    using var reader = new StreamReader(stream);
    var chunkNumber = 0;
    while (!reader.EndOfStream)
    {
        var buffer = new char[1024];
        var charsRead = await reader.ReadAsync(buffer);
        var chunkContent = new string(buffer, 0, charsRead);
        Console.WriteLine($"Chunk {chunkNumber} | Read {charsRead} bytes | {chunkContent}");
        chunkNumber++;
    }
    Console.WriteLine();
}


async Task GetPeople()
{
    Console.WriteLine("Getting people");

    var response = await httpClient.GetAsync("/people", HttpCompletionOption.ResponseHeadersRead);
    var stream = await response.Content.ReadAsStreamAsync();

    //var stream = await httpClient.GetStreamAsync("/people");

    using var reader = new StreamReader(stream);
    var chunkNumber = 0;
    while (!reader.EndOfStream)
    {
        var buffer = new char[1024];
        var charsRead = await reader.ReadAsync(buffer);
        var chunkContent = new string(buffer, 0, charsRead);
        Console.WriteLine($"Chunk {chunkNumber} | Read {charsRead} bytes | {chunkContent}");
        chunkNumber++;
    }
    Console.WriteLine();
}


async Task GetPeopleJson()
{
    Console.WriteLine("Getting people json");

    var response = await httpClient.GetAsync("/people-json", HttpCompletionOption.ResponseHeadersRead);
    var stream = await response.Content.ReadAsStreamAsync();

    //var stream = await httpClient.GetStreamAsync("/people-json");

    await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<object>(stream))
    {
        Console.WriteLine(item);
    }
    Console.WriteLine();
}