using LifeAssistant.Application.Common.Exceptions;
using LifeAssistant.Application.Common.Interfaces;
using LifeAssistant.Application.Models.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LifeAssistant.Application.Features.ToDos;

public sealed record GetTodoQuery(Guid Id) : IRequest<TodoDto>;

public sealed class GetTodoHandler(IAppDbContext db) : IRequestHandler<GetTodoQuery, TodoDto>
{
    public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todo = await db.Todos
            .AsNoTracking()
            .Include(t => t.Tags)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken) 
                   ?? throw new NotFoundException($"Todo with ID {request.Id} not found.");
        
        return todo.ToDto();
    }
}