using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.DAL.Configurations;

/// <summary>
/// Конфигурация для <see cref="Answer"/> 
/// </summary>
public class AnswerConfiguration : EntityBaseConfiguration<Answer>
{
    public override void ConfigureChild(EntityTypeBuilder<Answer> builder)
    {
        builder.Property(p => p.Name)
            .HasComment("Ответ");

        builder.Property(p => p.QuestionId)
            .HasComment("Идентификатор вопроса");

        builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(x => x.Results)
            .WithOne(y => y.Answer)
            .HasForeignKey(y => y.AnswerId)
            .HasPrincipalKey(x => x.Id);
    }
}