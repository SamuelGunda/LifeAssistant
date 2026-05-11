using LifeAssistant.Domain.Models.Common;
using LifeAssistant.Domain.Models.Enums;

namespace LifeAssistant.Domain.Models.Entities;

public sealed class Todo : PlannerItem
{
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority Priority { get; set; } = TodoPriority.None;
}