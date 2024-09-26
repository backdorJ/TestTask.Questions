namespace TestWorkQuestions.Core.Abstractions;

public interface IDbSeeder
{
    public Task SeedAsync(CancellationToken cancellationToken = new());
}