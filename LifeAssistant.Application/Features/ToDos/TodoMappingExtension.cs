using LifeAssistant.Application.Models.Dtos;
using LifeAssistant.Domain.Models.Entities;

namespace LifeAssistant.Application.Features.ToDos;

internal static class TodoMappingExtension
{
    internal static TodoDto ToDto(this Todo t) =>
        new(
            t.Id,
            t.Title,
            t.Description,
            t.Notes,
            t.DueDate,
            t.Priority,
            t.Status,
            t.CreatedAt,
            t.UpdatedAt,
            t.Tags.Select(tag => new TagSummaryResponse(tag.Id, tag.Name, tag.Color, tag.Icon))
                .ToList()
        );
}
