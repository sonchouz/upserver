
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using upserver.Data;
using upserver.DTO;
using upserver.services;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

var connectionString = $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
$"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
$"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
$"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
$"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}";

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IScheduleService, ScheduleService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<ExceptionMiddleware>;

app.UseAuthorization();
app.UseRouting();

app.MapControllers();
app.Run();
