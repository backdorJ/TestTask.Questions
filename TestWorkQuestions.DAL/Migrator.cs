using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestWorkQuestions.Core.Abstractions;

namespace TestWorkQuestions.DAL;

/// <summary>
/// Миграция
/// </summary>
public class Migrator
{
    private readonly EfContext _efContext;

    private readonly IDbSeeder _dbSeeder;
    private readonly ILogger<Migrator> _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="efContext">Точка входа в EfContext</param>
    /// <param name="logger">Логгер</param>
    /// <param name="dbSeeder">Seeder</param>
    public Migrator(EfContext efContext, ILogger<Migrator> logger, IDbSeeder dbSeeder)
    {
        _efContext = efContext;
        _logger = logger;
        _dbSeeder = dbSeeder;
    }

    /// <summary>
    /// Миграция
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    public async Task MigrateAsync(CancellationToken cancellationToken = new())
    {
        try
        {
            var migrationId = Guid.NewGuid();
            _logger.LogInformation($"Started migrate {migrationId}");
            await _efContext.Database.MigrateAsync(cancellationToken);
            await _dbSeeder.SeedAsync(cancellationToken);
            _logger.LogInformation($"Ended migrate {migrationId}");
        }
        catch (Exception e)
        {
            _logger.LogCritical($"Migrate failed: {e.Message}");
        }
    }
}