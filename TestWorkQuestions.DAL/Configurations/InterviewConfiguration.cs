using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.DAL.Configurations;

/// <summary>
/// Конфигурация для <see cref="Interview"/>
/// </summary>
public class InterviewConfiguration : EntityBaseConfiguration<Interview>
{
    public override void ConfigureChild(EntityTypeBuilder<Interview> builder)
    {
        builder.Property(p => p.SurveyId)
            .HasComment("Идентификатор анкеты");

        builder.HasOne(x => x.Survey)
            .WithOne(y => y.Interview);

        builder.HasMany(x => x.Results)
            .WithOne(y => y.Interview)
            .HasForeignKey(y => y.InterviewId)
            .HasPrincipalKey(x => x.Id);
    }
}