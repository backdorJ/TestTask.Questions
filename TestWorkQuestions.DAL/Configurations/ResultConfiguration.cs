using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.DAL.Configurations;

/// <summary>
/// Конфигурация для <see cref="Result"/>
/// </summary>
public class ResultConfiguration : EntityBaseConfiguration<Result>
{
    public override void ConfigureChild(EntityTypeBuilder<Result> builder)
    {
        builder.HasOne(x => x.Interview)
            .WithMany(y => y.Results)
            .HasForeignKey(x => x.InterviewId)
            .HasPrincipalKey(y => y.Id);

        builder.HasOne(x => x.Question)
            .WithMany(y => y.Results)
            .HasForeignKey(x => x.QuestionId)
            .HasPrincipalKey(y => y.Id);

        builder.HasOne(x => x.Answer)
            .WithMany(y => y.Results)
            .HasForeignKey(x => x.AnswerId)
            .HasPrincipalKey(y => y.Id);
    }
}