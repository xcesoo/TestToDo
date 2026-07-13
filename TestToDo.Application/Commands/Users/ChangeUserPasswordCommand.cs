using MediatR;
using TestToDo.Contracts.DTOs;

namespace TestToDo.Application.Commands.Users;

public readonly record struct ChangeUserPasswordCommand(string CurrentPassword, string NewPassword) : IRequest<TokenResponseDto>;