using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DemoWeb.Models;
using DemoWeb.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersContext>();
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

app.MapGet("/api/users", async (UsersContext db) => await db.Users.ToListAsync());
app.MapPost("/api/user/add", async (UsersContext db, Users user) =>
{
    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();
    return Results.Created($"/adduser/{user.Id}", user);
});

app.Run();
