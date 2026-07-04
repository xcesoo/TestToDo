using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Mappings;
using TestToDo.Entities;

namespace TestToDo.Application.Commands;

public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, ToDoItemDto>
{
    public Task<ToDoItemDto> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var item = ToDoItem.Create(
            title: request.Title,
            category: null, //todo
            deadline: request.Deadline,
            description: request.Description ?? "",
            priority: request.Priority);
        //todo save
        return Task.FromResult(item.ToDto());
    }
}