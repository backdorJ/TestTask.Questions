using MediatR;
using Microsoft.EntityFrameworkCore;
using TestWorkQuestions.Contracts.Requests.Questions.GetQuestionById;
using TestWorkQuestions.Core.Abstractions;

namespace TestWorkQuestions.Core.Requests.GetQuestionById;

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, GetQuestionByIdResponse>
{
    private readonly IDbContext _dbContext;

    public GetQuestionByIdQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetQuestionByIdResponse> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        return await _dbContext.Questions
            .Where(x => x.Id == request.Id)
            .Select(x => new GetQuestionByIdResponse
            {
                Name = x.Name,
                Answers = x.Answers!
                    .Select(y => new GetQuestionByIdResponseItem
                    {
                        AnswerId = y.Id,
                        AnswerName = y.Name
                    })
                    .ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new ApplicationException($"Не найден вопрос с идентификатором {request.Id}");
    }
}