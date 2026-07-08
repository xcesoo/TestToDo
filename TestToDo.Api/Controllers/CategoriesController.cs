using System.Collections.ObjectModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestToDo.Application.Commands;
using TestToDo.Application.Commands.Categories;
using TestToDo.Application.DTOs;
using TestToDo.Application.Queries.Categories;
using TestToDo.Entities;

namespace TestToDo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var ct = await mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
        return Ok(ct);
    }
    
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var ct = await  mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = ct.Id }, ct);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<CategoryDto>>> SearchByName([FromQuery]string name,
        CancellationToken cancellationToken)
    {
        var ct = await mediator.Send(new GetCategoryByNameQuery(name), cancellationToken);
        return Ok(ct);
    }
}