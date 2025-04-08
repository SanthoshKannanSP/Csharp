using System.Reflection;
using Microsoft.EntityFrameworkCore;
using task_10;
using task_10.Middlewares;
using task_10.Models;
using task_10.Repositories.Classes;
using task_10.Repositories.Interfaces;
using task_10.Services.Classes;
using task_10.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    }
    );

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BooksDb"));

builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
