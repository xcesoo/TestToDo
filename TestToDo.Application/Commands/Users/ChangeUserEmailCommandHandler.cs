using MediatR;

namespace TestToDo.Application.Commands.Users;

public class ChangeUserEmailCommandHandler : IRequestHandler<ChangeUserEmailCommand>
{
    public Task Handle(ChangeUserEmailCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}