using MediatR;
using TestToDo.Application.Extensions;
using TestToDo.Contracts.DTOs;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.Users;

public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
        return user?.ToDto();
    }
}