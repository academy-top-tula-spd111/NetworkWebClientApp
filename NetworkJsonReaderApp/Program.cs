using System.Net.Http.Json;
using System.Net;

HttpClient httpClient = new HttpClient();

//object data = await httpClient.GetFromJsonAsync("https://localhost:7194/", typeof(User));

//if (data is User user)
//    Console.WriteLine($"User name: {user.Name}, age: {user.Age}");

using var response = await httpClient.GetAsync("https://localhost:7194/1");

if(response.StatusCode == HttpStatusCode.BadRequest 
    || response.StatusCode == HttpStatusCode.NotFound)
{
    Error? error = await response.Content.ReadFromJsonAsync<Error>();
    Console.WriteLine($"Status Code: {response.StatusCode}, Message: {error?.Message}");
}
else
{
    User? user = await response.Content.ReadFromJsonAsync<User>();
    Console.WriteLine($"User name: {user.Name}, age: {user.Age}");
}

Console.ReadKey();

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Error
{
    public string Message { get; set; }
}