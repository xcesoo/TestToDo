using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Mappings;
using TestToDo.Entities;

namespace TestToDo.Application.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        //todo check if exist
        var category = Category.Create(request.Name);
        //todo saving
        return Task.FromResult(category.ToDto());
    }
}