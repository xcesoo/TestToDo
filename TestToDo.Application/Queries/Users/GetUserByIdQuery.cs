using MediatR;
using TestToDo.Contracts.DTOs;

namespace TestToDo.Application.Queries.Users;

public readonly record struct GetUserByIdQuery(Guid UserId) : IRequest<UserDto?>;