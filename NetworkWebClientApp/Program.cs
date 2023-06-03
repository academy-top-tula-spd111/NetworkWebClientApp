var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    context.Request.Headers.TryGetValue("User-Agent", out var userAgent);
    context.Request.Headers.TryGetValue("SecretCode", out var codeSecret);
    return $"User agent: {userAgent}, secret code: {codeSecret}";
});

app.MapGet("/{id?}", (int? id) =>
{
    if (id is null)
        return Results.BadRequest(new { Message = "Incorrect data in request" });
    else if (id != 1)
        return Results.NotFound(new { Message = $"User with id = {id} not found" });
    else
        return Results.Json(new User() { Name = "Bob", Age = 25 });
});

app.MapPost("/data", async (HttpContext context) => 
{
    using StreamReader reader = new(context.Request.Body);
    string text = await reader.ReadToEndAsync();
    return $"recived data: {text}";
});

app.MapPost("/user", async (User user) =>
{
    user.Id = Guid.NewGuid().ToString();
    return user;
});

app.Run();


class User
{
    public string Id { set; get; }
    public string Name { get; set; }
    public int Age { get; set; }
}