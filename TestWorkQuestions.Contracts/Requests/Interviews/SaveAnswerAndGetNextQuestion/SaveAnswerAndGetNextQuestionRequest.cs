namespace TestWorkQuestions.Contracts.Requests.Interviews.SaveAnswerAndGetNextQuestion;

public class SaveAnswerAndGetNextQuestionRequest
{
    /// <summary>
    /// Выбранный ответ
    /// </summary>
    public Guid SelectedAnswerId { get; set; }
}