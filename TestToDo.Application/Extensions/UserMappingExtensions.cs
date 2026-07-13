using TestToDo.Contracts.DTOs;
using TestToDo.Entities;

namespace TestToDo.Application.Extensions;

public static class UserMappingExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        (
            Id: user.Id,
            Name: user.Name,
            Email: user.Email,
            CreatedAt: user.CreatedAt
        );
    }

    public static IReadOnlyCollection<UserDto> ToDtoCollection(this IEnumerable<User> users)
    {
        return users.Select(c => c.ToDto()).ToArray();
    }
}