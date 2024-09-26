using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWorkQuestions.Contracts.Requests.Interviews.SaveAnswerAndGetNextQuestion;
using TestWorkQuestions.Core.Requests.Interviews.SaveAnswerAndGetNextQuestion;

namespace TestWorkQuestions.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InterviewController : ControllerBase
{
    [HttpPost("{interviewId}/addAnswer/{questionId}")]
    public async Task<SaveAnswerAndGetNextQuestionResponse> AddAnswerToQuestionAsync(
        [FromServices] IMediator mediator,
        [FromBody] SaveAnswerAndGetNextQuestionRequest request,
        [FromRoute] Guid interviewId,
        [FromRoute] Guid questionId,
        CancellationToken cancellationToken)
        => await mediator.Send(new SaveAnswerAndGetNextQuestionCommand(interviewId, questionId)
        {
            SelectedAnswerId = request.SelectedAnswerId
        }, cancellationToken);
}