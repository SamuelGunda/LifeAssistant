using LifeAssistant.Domain.Models.Enums;

namespace LifeAssistant.Application.Models.Dtos;

public sealed record TodoDto(
    Guid Id,
    string Title,
    string? Description,
    string? Notes,
    DateTimeOffset? DueDate,
    TodoPriority Priority,
    PlannerItemStatus Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt,
    IReadOnlyList<TagSummaryResponse> Tags
);

public sealed record TagSummaryResponse(Guid Id, string Name, string Color, string? Icon);
