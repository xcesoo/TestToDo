using MediatR;

namespace TestToDo.Application.Events;

public readonly record struct UserRegisteredEvent() : INotification;