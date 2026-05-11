using LifeAssistant.Application.Common.Interfaces;
using LifeAssistant.Domain.Models.Common;
using LifeAssistant.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeAssistant.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<PlannerItem> PlannerItems => Set<PlannerItem>();
    public DbSet<Todo> Todo => Set<Todo>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Attachment> Attachments => Set<Attachment>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}