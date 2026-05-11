using LifeAssistant.Application.Features.ToDos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeAssistant.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        => Ok(await mediator.Send(new GetTodoQuery(id), cancellationToken));

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoCommand command, CancellationToken cancellationToken)
        => Ok(await mediator.Send(command with { Id = id }, cancellationToken));
}