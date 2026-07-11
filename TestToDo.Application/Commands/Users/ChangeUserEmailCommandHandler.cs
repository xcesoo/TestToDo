using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class ChangeUserEmailCommandHandler(ICurrentUserProvider currentUser, IUserRepository userRepository) : IRequestHandler<ChangeUserEmailCommand>
{
    public async Task Handle(ChangeUserEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(currentUser.GetUserId(), cancellationToken)
            ?? throw new KeyNotFoundException("User not found");
        user.ChangeEmail(request.Email);
        await userRepository.SaveChangesAsync(cancellationToken);
    }
}