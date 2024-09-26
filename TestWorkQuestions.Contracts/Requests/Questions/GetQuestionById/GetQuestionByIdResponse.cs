namespace TestWorkQuestions.Contracts.Requests.Questions.GetQuestionById;

public class GetQuestionByIdResponse
{
    /// <summary>
    /// Название вопроса
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Ответы
    /// </summary>
    public List<GetQuestionByIdResponseItem>? Answers { get; set; }
}