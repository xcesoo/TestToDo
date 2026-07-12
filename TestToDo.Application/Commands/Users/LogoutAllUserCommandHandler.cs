using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class LogoutAllUserCommandHandler(IUserRepository userRepository, ICurrentUserProvider currentUser) : IRequestHandler<LogoutAllUserCommand>
{
    public async Task Handle(LogoutAllUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(currentUser.GetUserId(), cancellationToken)
                   ?? throw new KeyNotFoundException("User not found");
        user.RevokeAllRefreshTokens();
        await userRepository.SaveChangesAsync(cancellationToken);
    }
}