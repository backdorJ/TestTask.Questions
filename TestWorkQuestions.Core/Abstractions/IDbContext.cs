using Microsoft.EntityFrameworkCore;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.Core.Abstractions;

/// <summary>
/// Контекст Бд
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Ответы
    /// </summary>
    DbSet<Answer> Answers { get; set; }
    
    /// <summary>
    /// Информация об интервью
    /// </summary>
    DbSet<Interview> Interviews { get; set; }
    
    /// <summary>
    /// Вопрос анкеты
    /// </summary>
    DbSet<Question> Questions { get; set; }
    
    /// <summary>
    /// Данные ответов людей на вопросы анкеты
    /// </summary>
    DbSet<Result> Results { get; set; }
    
    /// <summary>
    /// Информация об анкете.
    /// </summary>
    DbSet<Survey> Surveys { get; set; }

    /// <summary>
    /// Сохранить
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}