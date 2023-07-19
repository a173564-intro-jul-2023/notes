using FirstApp.Models;

Console.WriteLine("Starting up the API");
var builder = WebApplication.CreateBuilder(args);
// All the configuration for the API will go here

Console.WriteLine("About to start the API");
var app = builder.Build();

// GET /sayhi
app.MapGet("/sayhi", () => {
    Console.WriteLine("GET request");
    return Results.Ok("Yep! Hello, good to see you!");
});

// GET /status
app.MapGet("/status", () => {
    var response = new StatusResponseModel(DateTime.Now, "Looks Good", "Operating Normally");
    return Results.Ok(response);
});

app.Run(); // Blocking call - this will start the server and run forever (or until we kill it)
Console.WriteLine("API is down");