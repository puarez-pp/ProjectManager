using minAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder; // Dodaj tê dyrektywê using

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ToDoDb>(options =>
    options.UseInMemoryDatabase("TodoItems"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todos", async (ToDoDb db) => await db.TodoItems.ToListAsync())
.WithName("GetTodos");

app.MapGet("/todos/{id}", async (int id, ToDoDb db) =>
    await db.TodoItems.FindAsync(id)
        is TodoItem todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/todos", async (TodoItem todo, ToDoDb db) =>
{
    db.TodoItems.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});

app.MapPut("/todos/{id}", async (int id, TodoItem inputTodo, ToDoDb db) =>
{
    var todo = await db.TodoItems.FindAsync(id);
    if (todo is null) return Results.NotFound();
    if(string.IsNullOrWhiteSpace(inputTodo.Title))
               return Results.BadRequest("Title cannot be empty.");
    db.Entry(todo).CurrentValues.SetValues(inputTodo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/todos/{id}", async (int id, ToDoDb db) =>
{
    var todo = await db.TodoItems.FindAsync(id);
    if (todo is null) return Results.NotFound();
    db.TodoItems.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();


