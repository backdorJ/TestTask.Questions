using MediatR;
using Microsoft.EntityFrameworkCore;
using TestWorkQuestions.Contracts.Requests.Interviews.SaveAnswerAndGetNextQuestion;
using TestWorkQuestions.Core.Abstractions;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.Core.Requests.Interviews.SaveAnswerAndGetNextQuestion;

public class SaveAnswerAndGetNextQuestionCommandHandler
    : IRequestHandler<SaveAnswerAndGetNextQuestionCommand, SaveAnswerAndGetNextQuestionResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public SaveAnswerAndGetNextQuestionCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SaveAnswerAndGetNextQuestionResponse> Handle(
        SaveAnswerAndGetNextQuestionCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var interview = await _dbContext.Interviews
            .Include(x => x.Survey)
                .ThenInclude(y => y!.Questions)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ApplicationException($"Не найдена информация об интервью с идентификатором {request.Id}");
        
        var question = await _dbContext.Questions
            .FirstOrDefaultAsync(x => x.Id == request.QuestionId, cancellationToken)
            ?? throw new ApplicationException($"Не найден вопрос с идентификатором {request.QuestionId}");
        
        var selectedAnswer = await _dbContext.Answers
            .FirstOrDefaultAsync(x => x.Id == request.SelectedAnswerId, cancellationToken)
            ?? throw new ApplicationException($"Не найден ответ с идентификатором {request.SelectedAnswerId}");

        var result = new Result(interview, question, selectedAnswer);

        _dbContext.Results.Add(result);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var nextQuestion = interview.Survey?.Questions?
            .Where(x => x.Position != question.Position)
            .FirstOrDefault(x => x.Position > question.Position);

        return new SaveAnswerAndGetNextQuestionResponse
        {
            NextQuestionId = nextQuestion?.Id,
        };
    }
}