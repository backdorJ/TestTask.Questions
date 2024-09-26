using Microsoft.EntityFrameworkCore;
using TestWorkQuestions.Core;
using TestWorkQuestions.Core.Abstractions;
using TestWorkQuestions.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IDbContext, EfContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQL")));
builder.Services.AddDal();
builder.Services.AddCore();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetRequiredService<Migrator>();
await migrator.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();