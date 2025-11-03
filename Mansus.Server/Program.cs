using Microsoft.EntityFrameworkCore;

using Mansus.Server.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Local")
    )
);

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
