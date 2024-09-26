namespace TestWorkQuestions.Core.Entities;

/// <summary>
/// Данные ответов людей на вопросы анкеты
/// </summary>
public class Result : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="interview">Информация об интервью (отдельной сессии прохождения анкеты</param>
    /// <param name="question">Вопрос</param>
    /// <param name="answer">Ответ</param>
    public Result(Interview interview, Question? question, Answer answer)
    {
        Interview = interview;
        Question = question;
        Answer = answer;
    }

    private Result()
    {
    }

    /// <summary>
    /// Идентификатор Информация об интервью
    /// </summary>
    public Guid InterviewId { get; set; }

    /// <summary>
    /// Идентификатор Вопрос
    /// </summary>
    public Guid QuestionId { get; set; }

    /// <summary>
    /// Идентификатор Ответ
    /// </summary>
    public Guid AnswerId { get; set; }
    
    /// <summary>
    /// Информация об интервью (отдельной сессии прохождения анкеты
    /// </summary>
    public Interview? Interview { get; set; }

    /// <summary>
    /// Вопрос
    /// </summary>
    public Question? Question { get; set; }

    /// <summary>
    /// Ответ
    /// </summary>
    public Answer? Answer { get; set; }
}