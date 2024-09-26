namespace TestWorkQuestions.Core.Entities;

/// <summary>
/// Информация об интервью (отдельной сессии прохождения анкеты конкретным человеком)
/// </summary>
public class Interview : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="survey">Анкета</param>
    public Interview(Survey? survey)
    {
        Survey = survey;
        Results = new List<Result>();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Interview()
    {
    }

    /// <summary>
    /// Идентификатор анкеты
    /// </summary>
    public Guid SurveyId { get; set; }
    
    /// <summary>
    /// Анкета
    /// </summary>
    public Survey? Survey { get; set; }

    /// <summary>
    /// Результат
    /// </summary>
    public List<Result>? Results { get; set; }
}