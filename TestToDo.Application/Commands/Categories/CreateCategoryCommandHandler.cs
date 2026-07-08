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
        var c = await categoryRepository.GetCategoryByName(request.CategoryName, cancellationToken);
        if (c != null) throw new ArgumentException($"Category with name {request.CategoryName} already exists");
        
        c = Category.Create(request.CategoryName);
        await categoryRepository.AddCategory(c, cancellationToken);
        await categoryRepository.SaveChangesAsync(cancellationToken);
        return c.ToDto();
    }
}