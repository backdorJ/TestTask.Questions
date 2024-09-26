namespace TestWorkQuestions.Core.Entities;

/// <summary>
/// Вопрос анкеты
/// </summary>
public class Question : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название вопроса</param>
    /// <param name="position">Нумерация вопроса</param>
    /// <param name="correctAnswer">Правильный ответ</param>
    /// <param name="answers">Ответы</param>
    public Question(
        string name,
        int position,
        Answer? correctAnswer = default,
        List<Answer>? answers = default)
    {
        Name = name;
        Position = position;
        CorrectAnswer = correctAnswer;
        Answers = answers ?? new List<Answer>();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Question()
    {
    }

    /// <summary>
    /// Название вопроса
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Нумерация вопроса
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Идентификатор Анкеты
    /// </summary>
    public Guid SurveyId { get; set; }
    
    /// <summary>
    /// Анкета
    /// </summary>
    public Survey Survey { get; set; }

    /// <summary>
    /// Идентификатор Правильный ответ
    /// </summary>
    public Guid? CorrectAnswerId { get; set; }
    
    /// <summary>
    /// Правильный ответ
    /// </summary>
    public Answer? CorrectAnswer { get; set; }
    
    /// <summary>
    /// Ответы
    /// </summary>
    public List<Answer>? Answers { get; set; }

    /// <summary>
    /// Результаты
    /// </summary>
    public List<Result> Results { get; set; }
}