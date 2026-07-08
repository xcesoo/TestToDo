using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Mappings;
using TestToDo.Entities;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Categories;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        //todo check if exist by name
        var category = Category.Create(request.Name);
        await categoryRepository.AddCategory(category, cancellationToken);
        await categoryRepository.SaveChangesAsync(cancellationToken);
        return category.ToDto();
    }
}