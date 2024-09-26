using Microsoft.Extensions.DependencyInjection;

namespace TestWorkQuestions.DAL;

public static class Entry
{
    public static void AddDal(this IServiceCollection services)
    {
        services.AddTransient<Migrator>();
    }
}