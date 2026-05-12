using FluentValidation;
using LifeAssistant.Application.Common.Interfaces;
using LifeAssistant.Application.Models.Dtos;
using LifeAssistant.Domain.Models.Entities;
using LifeAssistant.Domain.Models.Enums;
using MediatR;

namespace LifeAssistant.Application.Features.ToDos;

public sealed record CreateTodoCommand(
    string Title,
    string? Description,
    string? Notes,
    DateTimeOffset? DueDate,
    TodoPriority Priority,
    PlannerItemStatus Status
    ) : IRequest<TodoDto>;

public sealed class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(x => x.Description)
            .MaximumLength(1000);
        RuleFor(x => x.Notes)
            .MaximumLength(1000);
        RuleFor(x => x.Priority)
            .IsInEnum();
        RuleFor(x => x.Status)
            .IsInEnum();
    }
}

public sealed class CreateTodoHandler(IAppDbContext db) : IRequestHandler<CreateTodoCommand, TodoDto>
{
    public async Task<TodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo
        {
            Title = request.Title,
            Description = request.Description,
            Notes = request.Notes,
            DueDate = request.DueDate,
            Priority = request.Priority,
            Status = request.Status
        };

        db.Todos.Add(todo);
        await db.SaveChangesAsync(cancellationToken);

        return todo.ToDto();
    }
}