namespace TestToDo.Application.Interfaces;

public interface ICurrentUserProvider
{
    Guid GetUserId();
}