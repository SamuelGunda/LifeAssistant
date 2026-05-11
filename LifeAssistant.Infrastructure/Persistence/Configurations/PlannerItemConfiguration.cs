using LifeAssistant.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeAssistant.Infrastructure.Persistence.Configurations;

public sealed class PlannerItemConfiguration : IEntityTypeConfiguration<PlannerItem>
{
    public void Configure(EntityTypeBuilder<PlannerItem> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Description).HasMaxLength(1000);
        builder.Property(s => s.Notes).HasMaxLength(1000);

        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.UpdatedAt).IsRequired();
        
        builder.HasQueryFilter(s => s.DeletedAt == null);
        
        builder.HasMany(s => s.Tags)
            .WithMany(t => t.PlannerItems)
            .UsingEntity(j => j.ToTable("PlannerItemTags"));
        
        builder.OwnsMany(s => s.Attachments, a =>
        {
            a.ToTable("Attachments");
            a.HasKey(x => x.Id);
            a.Property(x => x.FileName).IsRequired().HasMaxLength(50);
            a.Property(x => x.StorageUrl).IsRequired().HasMaxLength(200);
        });
    }
}