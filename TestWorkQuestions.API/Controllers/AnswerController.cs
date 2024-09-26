using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWorkQuestions.Contracts.Requests.Questions.GetQuestionById;
using TestWorkQuestions.Core.Requests.GetQuestionById;

namespace TestWorkQuestions.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    /// <summary>
    /// Получить вопрос по идентификатору
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Вопрос</returns>
    [HttpGet("{id}")]
    public async Task<GetQuestionByIdResponse> GetByIdAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetQuestionByIdQuery(id), cancellationToken);
}