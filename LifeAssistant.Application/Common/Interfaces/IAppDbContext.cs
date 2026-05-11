using LifeAssistant.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeAssistant.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Todo> Todos { get; }
    DbSet<Tag> Tags { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}