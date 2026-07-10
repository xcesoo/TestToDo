using MediatR;

namespace TestToDo.Application.Commands.Users;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand>
{
    public Task Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}