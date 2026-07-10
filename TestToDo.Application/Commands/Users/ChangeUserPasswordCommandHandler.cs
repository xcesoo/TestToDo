using MediatR;

namespace TestToDo.Application.Commands.Users;

public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand>
{
    public Task Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}