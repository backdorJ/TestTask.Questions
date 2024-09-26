using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.DAL.Configurations;

/// <summary>
/// Конфигурация для <see cref="Survey"/>
/// </summary>
public class SurveyConfiguration : EntityBaseConfiguration<Survey>
{
    public override void ConfigureChild(EntityTypeBuilder<Survey> builder)
    {
        builder.Property(p => p.Name)
            .HasComment("Название анкеты");

        builder.Property(p => p.Description)
            .HasComment("Описание анкеты");

        builder.HasOne(x => x.Interview)
            .WithOne(y => y.Survey);
        
        builder.HasMany(x => x.Questions)
            .WithOne(y => y.Survey)
            .HasForeignKey(x => x.SurveyId)
            .HasPrincipalKey(x => x.Id);
    }
}