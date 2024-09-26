using Microsoft.EntityFrameworkCore;
using TestWorkQuestions.Core.Abstractions;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.DAL;

/// <summary>
/// Точка входа в EfContext
/// </summary>
public class EfContext : DbContext, IDbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Ответы
    /// </summary>
    public DbSet<Answer> Answers { get; set; }
    
    /// <summary>
    /// Информация об интервью
    /// </summary>
    public DbSet<Interview> Interviews { get; set; }
    
    /// <summary>
    /// Вопрос анкеты
    /// </summary>
    public DbSet<Question> Questions { get; set; }
    
    /// <summary>
    /// Данные ответов людей на вопросы анкеты
    /// </summary>
    public DbSet<Result> Results { get; set; }
    
    /// <summary>
    /// Информация об анкете.
    /// </summary>
    public DbSet<Survey> Surveys { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
}