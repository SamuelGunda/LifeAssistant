using LifeAssistant.Domain.Models.Common;

namespace LifeAssistant.Domain.Models.Entities;

public sealed class Tag
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public string Color { get; set; } = "#000000";
    public string? Icon { get; set; }
    public Guid OwnerId { get; set; }

    public ICollection<PlannerItem> PlannerItems { get; set; } = new List<PlannerItem>();
}
