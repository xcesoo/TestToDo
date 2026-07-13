using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestToDo.Application.Commands.Categories;
using TestToDo.Application.Queries.Categories;
using TestToDo.Contracts.DTOs;
using TestToDo.Contracts.Requests;

namespace TestToDo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    //GET
    [HttpGet("{id:guid}")] 
    [Authorize]
    public async Task<ActionResult<CategoryDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var ct = await mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
        return ct is null ? NotFound() : Ok(ct);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IReadOnlyCollection<CategoryDto>>> SearchByName([FromQuery]string nameFilter,
        CancellationToken cancellationToken)
    {
        var ct = await mediator.Send(new SearchCategoriesByNameQuery(nameFilter), cancellationToken);
        return Ok(ct);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<ActionResult<CategoryDto>> SearchByCategory(string name, CancellationToken cancellationToken)
    {
        var ct = await mediator.Send(new GetCategoryByNameQuery(name), cancellationToken);
        return ct is null ? NotFound() : Ok(ct);
    }
    //GET
    
    //POST
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var ct = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = ct.Id }, ct);
    }
    //POST
    
    //PATCH
    [HttpPatch("{id:guid}/name")]
    [Authorize]
    public async Task<IActionResult> ChangeName(Guid id, [FromBody] ChangeNameRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeCategoryNameCommand(id, request.Name), cancellationToken);
        return NoContent();
    }
    //PATCH
    
    //DELETE
    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
        return NoContent();
    }
    //DELETE
}