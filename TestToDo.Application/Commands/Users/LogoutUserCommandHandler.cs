using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class LogoutUserCommandHandler(IUserRepository userRepository, ICurrentUserProvider currentUser) : IRequestHandler<LogoutUserCommand>
{
    public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(currentUser.GetUserId(), cancellationToken)
            ?? throw new KeyNotFoundException("User not found");
        user.RevokeRefreshToken(request.RefreshToken);
        await userRepository.SaveChangesAsync(cancellationToken);
    }
}