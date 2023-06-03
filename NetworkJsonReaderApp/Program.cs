using System.Net.Http.Json;
using System.Net;

HttpClient httpClient = new HttpClient();

//object data = await httpClient.GetFromJsonAsync("https://localhost:7194/", typeof(User));

//if (data is User user)
//    Console.WriteLine($"User name: {user.Name}, age: {user.Age}");

//using var response = await httpClient.GetAsync("https://localhost:7194/1");
/*
httpClient.DefaultRequestHeaders.Add("User-Agent", "Yandex Browser Academy");
httpClient.DefaultRequestHeaders.Add("SecretCode", "Maxim secret code");

using var response = await httpClient.GetAsync("https://localhost:7194/");

if (response.StatusCode == HttpStatusCode.BadRequest 
    || response.StatusCode == HttpStatusCode.NotFound)
{
    Error? error = await response.Content.ReadFromJsonAsync<Error>();
    Console.WriteLine($"Status Code: {response.StatusCode}, Message: {error?.Message}");
}
else
{
    //User? user = await response.Content.ReadFromJsonAsync<User>();
    //Console.WriteLine($"User name: {user.Name}, age: {user.Age}");

    var text = await response.Content.ReadAsStringAsync();
    Console.WriteLine(text);
}
*/

/*
StringContent content = new("Text for body of request");
using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7194/data");
request.Content = content;

var response = await httpClient.SendAsync(request);

string text = await response.Content.ReadAsStringAsync();
Console.WriteLine(text);
*/

User user = new() { Name = "Bobby", Age = 26 };
JsonContent content = JsonContent.Create(user);
try
{
    using var response = await httpClient.PostAsync("https://localhost:7194/user", content);
    User? user2 = await response.Content.ReadFromJsonAsync<User>();

    Console.WriteLine($"User name: {user2?.Name}, age: {user2?.Age}");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}



Console.ReadKey();

class User
{
    public string Id { set; get; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Error
{
    public string Message { get; set; }
}