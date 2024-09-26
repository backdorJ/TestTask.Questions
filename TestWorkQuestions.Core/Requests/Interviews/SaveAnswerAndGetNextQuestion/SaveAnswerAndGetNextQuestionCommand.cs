using MediatR;
using TestWorkQuestions.Contracts.Requests.Interviews.SaveAnswerAndGetNextQuestion;

namespace TestWorkQuestions.Core.Requests.Interviews.SaveAnswerAndGetNextQuestion;

public class SaveAnswerAndGetNextQuestionCommand
    : SaveAnswerAndGetNextQuestionRequest, IRequest<SaveAnswerAndGetNextQuestionResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор сессии конкретного человека</param>
    /// <param name="questionId">Идентификатор вопроса</param>
    public SaveAnswerAndGetNextQuestionCommand(Guid id, Guid questionId)
    {
        Id = id;
        QuestionId = questionId;
    }

    /// <summary>
    /// Идентификатор сессии конкретного человека
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор вопроса
    /// </summary>
    public Guid QuestionId { get; set; }
}