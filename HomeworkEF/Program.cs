using HomeworkEF.Models;
using HomeworkEF.Infrastructure.Repositories;
using HomeworkEF.Services;
using Microsoft.AspNetCore.Cors;
using HomeworkEF.Infrastructure;
using Microsoft.EntityFrameworkCore;
using HomeworkEF.Infrastructure.UoW;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoDbContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}
));

var app = builder.Build();
app.UseCors("corspolicy");
app.MapControllers();
app.Run();