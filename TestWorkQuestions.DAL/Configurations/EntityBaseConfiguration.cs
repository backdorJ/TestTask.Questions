using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWorkQuestions.Core.Entities;

namespace TestWorkQuestions.DAL.Configurations;

public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        ConfigureChild(builder);
    }

    /// <summary>
    /// Сконфигурировать остальные свойства
    /// </summary>
    /// <param name="builder">Билдер</param>
    public abstract void ConfigureChild(EntityTypeBuilder<TEntity> builder);
}