using FluentValidation;
using LifeAssistant.Application.Common.Exceptions;
using LifeAssistant.Application.Common.Interfaces;
using LifeAssistant.Application.Common.Models;
using LifeAssistant.Application.Models.Dtos;
using LifeAssistant.Domain.Models.Enums;
using MediatR;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace LifeAssistant.Application.Features.ToDos;

public sealed record UpdateTodoCommand(
    [property: JsonIgnore] Guid Id,
    string? Title,
    Optional<string?> Description,
    Optional<string?> Notes,
    Optional<DateTimeOffset?> DueDate,
    TodoPriority? Priority,
    PlannerItemStatus? Status
) : IRequest<TodoDto>;

public sealed class UpdateTodoValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().When(x => x.Title is not null)
            .MaximumLength(50);
        RuleFor(x => x.Description.Value)
            .MaximumLength(1000)
            .When(x => x.Description.HasValue);
        RuleFor(x => x.Notes.Value)
            .MaximumLength(1000)
            .When(x => x.Notes.HasValue);
    }
}

public sealed class UpdateTodoHandler(IAppDbContext db) : IRequestHandler<UpdateTodoCommand, TodoDto>
{
    public async Task<TodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await db.Todos
            .Include(t => t.Tags)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException($"Todo with ID {request.Id} not found.");

        if (request.Title is not null) todo.Title = request.Title;
        if (request.Description.HasValue) todo.Description = request.Description.Value;
        if (request.Notes.HasValue) todo.Notes = request.Notes.Value;
        if (request.DueDate.HasValue) todo.DueDate = request.DueDate.Value;
        if (request.Priority is not null) todo.Priority = request.Priority.Value;
        if (request.Status is not null) todo.Status = request.Status.Value;

        todo.UpdatedAt = DateTimeOffset.UtcNow;

        await db.SaveChangesAsync(cancellationToken);

        return todo.ToDto();
    }
}
