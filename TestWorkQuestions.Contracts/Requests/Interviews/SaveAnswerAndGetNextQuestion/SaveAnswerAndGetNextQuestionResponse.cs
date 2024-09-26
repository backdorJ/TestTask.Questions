namespace TestWorkQuestions.Contracts.Requests.Interviews.SaveAnswerAndGetNextQuestion;

public class SaveAnswerAndGetNextQuestionResponse
{
    /// <summary>
    /// Идентификатор следующего вопроса
    /// </summary>
    public Guid? NextQuestionId { get; set; }
}