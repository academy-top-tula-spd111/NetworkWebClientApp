var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/{id?}", (int? id) =>
{
    if (id is null)
        return Results.BadRequest(new { Message = "Incorrect data in request" });
    else if (id != 1)
        return Results.NotFound(new { Message = $"User with id = {id} not found" });
    else
        return Results.Json(new User() { Name = "Bob", Age = 25 });
});

app.Run();


class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}