using Microsoft.Extensions.DependencyInjection;
using TestWorkQuestions.Core.Abstractions;
using TestWorkQuestions.Core.Services;

namespace TestWorkQuestions.Core;

/// <summary>
/// Входная точка Core
/// </summary>
public static class Entry
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddScoped<IDbSeeder, DbSeeder>();
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Entry).Assembly));
    }
}