using LifeAssistant.Domain.Models.Entities;
using LifeAssistant.Domain.Models.Enums;

namespace LifeAssistant.Domain.Models.Common;

public abstract class PlannerItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public PlannerItemStatus Status { get; set; } = PlannerItemStatus.Todo;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}
