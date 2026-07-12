using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Extensions;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.Users;

public class GetUserByEmailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
        return user?.ToDto();
    }
}