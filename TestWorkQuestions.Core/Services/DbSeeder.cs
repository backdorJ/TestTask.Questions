using Microsoft.EntityFrameworkCore;
using TestWorkQuestions.Core.Abstractions;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.Core.Services;

public class DbSeeder : IDbSeeder
{
    private readonly IDbContext _dbContext;

    private readonly string[] _surveyNames = new string[]
    {
        "survey-1"
    };

    public DbSeeder(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = new())
    {
        await SeedDataAsync(cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task SeedDataAsync(CancellationToken cancellationToken)
    {
        var allSurveys = await _dbContext.Surveys
            .ToListAsync(cancellationToken);

        var toAdd = _surveyNames
            .Where(x => allSurveys.All(y => y.Name != x))
            .ToList();

        var toDelete = allSurveys
            .Where(x => !_surveyNames.Contains(x.Name))
            .ToList();

        if (toDelete.Any())
            _dbContext.Surveys.RemoveRange(toDelete);

        if (!toAdd.Any())
            return;

        // Создаем ответы
        var answer1 = new Answer("6");
        var answer2 = new Answer("7");
        var answer3 = new Answer("8");
        var answer4 = new Answer("5");
        var correctAnswer = new Answer("4");

        var nextAnswer = new Answer("Земля");
        var correctnextAnswer2 = new Answer("Юпитер");
        var nextAnswer3 = new Answer("Марс");
        var nextAnswer4 = new Answer("Венера");

        // Добавляем ответы в контекст
        await _dbContext.Answers.AddRangeAsync(answer1, answer2, answer3, answer4, correctAnswer);
        await _dbContext.Answers.AddRangeAsync(nextAnswer, correctnextAnswer2, nextAnswer3, nextAnswer4);
        await _dbContext.SaveChangesAsync(cancellationToken); // Сохраняем, чтобы получить Id

        // Создаем вопрос с уже добавленными ответами
        var question = new Question(
            name: "Сколько в мире океанов?", position: 1,
            correctAnswer: correctAnswer,
            answers: new List<Answer> { answer1, answer2, answer3, answer4, correctAnswer });

        var question2 = new Question(
            name: "Какая планета самая большая в Солнечной системе?", position: 2,
            correctAnswer: correctnextAnswer2, answers: new List<Answer>()
            {
                correctnextAnswer2,
                nextAnswer3,
                nextAnswer4,
                nextAnswer,
            });

        // Создаем опрос
        var survey = new Survey(
            name: "survey-1",
            description: "desc survey-1",
            questions: new List<Question> { question, question2 });

        // Добавляем опрос в контекст и сохраняем
        await _dbContext.Surveys.AddAsync(survey, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken); // Сохраняем изменения

        var interview = new Interview(survey);

        await _dbContext.Interviews.AddAsync(interview, cancellationToken);
    }
}