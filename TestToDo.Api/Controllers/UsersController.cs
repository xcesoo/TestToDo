using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestToDo.Application.Commands.Users;
using TestToDo.Application.Queries.Users;
using TestToDo.Contracts.Requests;

namespace TestToDo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    //GET
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await mediator.Send(new GetAllUsersQuery());
        return Ok(user);
    }
    
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var user = await mediator.Send(new GetUserByIdQuery(userId));
        return user is null ? NotFound() : Ok(user);
    }
    
    [HttpGet("/by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery]string email)
    {
        var user = await mediator.Send(new GetUserByEmailQuery(email));
        return user is null ? NotFound() : Ok(user);
    }
    //GET

    //POST
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var t = await mediator.Send(new RegisterUserCommand(request.Email, request.Password, request.Name), cancellationToken); 
        return Ok(t);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        var t = await mediator.Send(new LoginUserCommand(request.Email, request.Password), cancellationToken); 
        return Ok(t);
    }
    
    [HttpPost("token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenUserRequest request, CancellationToken cancellationToken)
    {
        var t = await mediator.Send(new RefreshTokenUserCommand(request.RefreshToken), cancellationToken); 
        return Ok(t);
    }
    //POST
    
    //PATCH
    [HttpPatch("email")]
    [Authorize]
    public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailUserRequest request, CancellationToken cancellationToken)
    { 
        await mediator.Send(new ChangeUserEmailCommand(request.Email), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordUserRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeUserPasswordCommand(request.CurrentPassword, request.NewPassword), cancellationToken); 
        return NoContent();
    }
    
    [HttpPatch("name")]
    [Authorize]
    public async Task<IActionResult> ChangeName([FromBody] ChangeNameUserRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new ChangeUserNameCommand(request.Name), cancellationToken); 
        return NoContent();
    }
    //PATCH
    
    //DELETE
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete(CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserCommand(), cancellationToken); 
        return NoContent();
    }
    
    [HttpDelete("logout")]
    [Authorize]
    public async Task<IActionResult> Logout([FromBody] LogoutUserRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new LogoutUserCommand(request.RefreshToken), cancellationToken);
        return NoContent();
    }
    [HttpDelete("logout/all")]
    [Authorize]
    public async Task<IActionResult> LogoutAll(CancellationToken cancellationToken)
    {
        await mediator.Send(new LogoutAllUserCommand(), cancellationToken);
        return NoContent();
    }
    //DELETE
}