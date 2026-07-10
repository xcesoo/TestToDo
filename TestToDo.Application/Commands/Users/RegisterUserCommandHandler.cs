using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Commands.Users;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
{
    public Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}