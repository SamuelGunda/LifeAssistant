using LifeAssistant.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeAssistant.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Todo> Todo { get; }
    DbSet<Tag> Tags { get; }
    DbSet<Attachment> Attachments { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}