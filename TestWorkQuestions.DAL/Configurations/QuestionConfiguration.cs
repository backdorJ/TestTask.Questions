using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.DAL.Configurations;

/// <summary>
/// Конфигурация для <see cref="Question"/>
/// </summary>
public class QuestionConfiguration : EntityBaseConfiguration<Question>
{
    public override void ConfigureChild(EntityTypeBuilder<Question> builder)
    {
        builder.Property(p => p.Name)
            .HasComment("Название вопроса");

        builder.Property(p => p.Position)
            .HasComment("Номер вопроса");

        builder.HasOne(x => x.Survey)
            .WithMany(y => y.Questions)
            .HasForeignKey(x => x.SurveyId)
            .HasPrincipalKey(y => y.Id);
        
        builder.HasMany(x => x.Answers)
            .WithOne(y => y.Question)
            .HasForeignKey(y => y.QuestionId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(q => q.CorrectAnswer)
            .WithMany()
            .HasForeignKey(q => q.CorrectAnswerId);

        builder.HasMany(x => x.Results)
            .WithOne(y => y.Question)
            .HasForeignKey(y => y.QuestionId)
            .HasPrincipalKey(x => x.Id);
    }
}