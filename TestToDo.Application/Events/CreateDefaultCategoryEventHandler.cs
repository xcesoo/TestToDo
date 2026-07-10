using MediatR;

namespace TestToDo.Application.Events;

public class CreateDefaultCategoryEventHandler : INotificationHandler<UserRegisteredEvent>
{
    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}