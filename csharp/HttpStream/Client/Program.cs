var httpClient = new HttpClient
{
    BaseAddress = new("https://localhost:7182"),
};


Console.WriteLine("Getting chars");
var response = await httpClient.GetAsync("/chars", HttpCompletionOption.ResponseHeadersRead);
var stream  = await response.Content.ReadAsStreamAsync();

//var stream = await httpClient.GetStreamAsync("/chars");

using var reader = new StreamReader(stream);
while (!reader.EndOfStream)
{
    var c = (char)reader.Read();
    Console.Write(c);
}
Console.WriteLine();


Console.WriteLine("Getting people");
var response2 = await httpClient.GetAsync("/people", HttpCompletionOption.ResponseHeadersRead);
var stream2  = await response2.Content.ReadAsStreamAsync();

//var stream2 = await httpClient.GetStreamAsync("/people");

using var reader2 = new StreamReader(stream2);
while (!reader2.EndOfStream)
{
    var c = (char)reader2.Read();
    Console.Write(c);
}
Console.WriteLine();