using MediatR;
using TestWorkQuestions.Contracts.Requests.Questions.GetQuestionById;

namespace TestWorkQuestions.Core.Requests.GetQuestionById;

public class GetQuestionByIdQuery : IRequest<GetQuestionByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор вопроса</param>
    public GetQuestionByIdQuery(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор вопроса
    /// </summary>
    public Guid Id { get; }
}