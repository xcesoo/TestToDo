using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Users;

public class ChangeUserNameCommandHandler(ICurrentUserProvider currentUser, IUserRepository userRepository) : IRequestHandler<ChangeUserNameCommand>
{
    public async Task Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(currentUser.GetUserId(), cancellationToken)
                   ?? throw new KeyNotFoundException("User not found");
        user.ChangeName(request.Name);
        await userRepository.SaveChangesAsync(cancellationToken);
    }
}