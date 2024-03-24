using API.BuilderRegister;
using API.Entities;
using API.Services;
using API.UOW;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddAppBuilder(app.Environment.IsDevelopment());

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/todo", async (IUnitOfWork _unitOfWork) => await _unitOfWork.TodoService.GetAll())
    .WithName("GetAllToDo")
    .WithOpenApi();

app.MapPost("/add/todo", async (IUnitOfWork _unitOfWork,Todo entity) =>
    {
         await _unitOfWork.TodoService.Add(entity);
         await _unitOfWork.TodoService.Save();
    })
    .WithName("AddToDo")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}