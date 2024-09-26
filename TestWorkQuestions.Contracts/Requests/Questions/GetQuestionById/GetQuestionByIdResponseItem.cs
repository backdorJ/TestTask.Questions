namespace TestWorkQuestions.Contracts.Requests.Questions.GetQuestionById;

public class GetQuestionByIdResponseItem
{
    /// <summary>
    /// Ответ
    /// </summary>
    public Guid AnswerId { get; set; }

    /// <summary>
    /// Название ответа
    /// </summary>
    public string AnswerName { get; set; } = default!;
}