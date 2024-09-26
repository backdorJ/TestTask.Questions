namespace TestWorkQuestions.Core.Entities;

/// <summary>
/// Вариант ответа на вопрос анкеты
/// </summary>
public class Answer : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Ответ</param>
    /// <param name="question">Вопрос</param>
    public Answer(string name, Question? question = default)
    {
        Name = name;
        Question = question;
        Results = new List<Result>();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Answer()
    {
    }

    /// <summary>
    /// Ответ
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Идентификатор вопроса
    /// </summary>
    public Guid? QuestionId { get; private set; }

    /// <summary>
    /// Вопрос
    /// </summary>
    public Question? Question { get; set; }

    /// <summary>
    /// Результаты
    /// </summary>
    public List<Result> Results { get; set; }
}