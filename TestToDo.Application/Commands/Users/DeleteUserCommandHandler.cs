using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class DeleteUserCommandHandler(ICurrentUserProvider currentUser, IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await userRepository.DeleteUserAsync(currentUser.GetUserId(), cancellationToken);
    }
}