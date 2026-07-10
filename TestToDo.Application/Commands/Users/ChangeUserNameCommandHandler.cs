using MediatR;

namespace TestToDo.Application.Commands.Users;

public class ChangeUserNameCommandHandler : IRequestHandler<ChangeUserNameCommand>
{
    public Task Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}