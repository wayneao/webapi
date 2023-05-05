using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DemoWeb.Models;
using DemoWeb.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo
       {
           Title = "DemoWeb API",
           Description = "演示项目",
           Version = "v1"
       });
   });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoWeb API v1");
   });

// Routers
app.MapGet("/api/users", async (UserContext db) => 
    await db.Users.ToListAsync());
app.MapGet("/api/user/get/{id}", async (long id, UserContext db) =>
    await db.Users.FindAsync(id)
        is User user
            ? Results.Ok(user)
            : Results.NotFound());
app.MapPost("/api/user/create", async (UserContext db, User user) =>
{
    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();
    return Results.Created($"/adduser/{user.Id}", user);
});

app.Run();
