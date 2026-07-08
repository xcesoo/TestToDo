using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestToDo.Application.Commands;
using TestToDo.Application.DTOs;

namespace TestToDo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var ct = await  mediator.Send(command, cancellationToken);
        return CreatedAtAction("todo", new { id = ct.Id }, ct);
    }
}