using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestToDo.Application.Commands;
using TestToDo.Application.DTOs;
using TestToDo.Application.Queries;
using TestToDo.Entities;

namespace TestToDo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ToDoItemDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var item = await mediator.Send(new GetToDoItemByIdQuery(id), cancellationToken);
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItemDto>> Create([FromBody] CreateToDoItemCommand command,  CancellationToken cancellationToken)
    {
        var item = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }
}