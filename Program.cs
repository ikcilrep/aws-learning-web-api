using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelloWorld.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HelloWorldContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("HelloWorldContext") ?? throw new InvalidOperationException("Connection string 'HelloWorldContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine("Health.");

app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/healthz");

app.Run();