namespace TestWorkQuestions.Core.Entities;

/// <summary>
/// Информация об анкете.
/// </summary>
public class Survey : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название анкеты</param>
    /// <param name="description">Описание анкеты</param>
    /// <param name="questions">Вопросы</param>
    public Survey(
        string name,
        string description,
        IReadOnlyList<Question>? questions = default)
    {
        Name = name;
        Description = description;
        Questions = questions ?? new List<Question>();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Survey()
    {
    }

    /// <summary>
    /// Название анкеты
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание анкеты
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Информация об интервью
    /// </summary>
    public Interview? Interview { get; set; }

    /// <summary>
    /// Вопросы
    /// </summary>
    public IReadOnlyList<Question>? Questions { get; set; }
}