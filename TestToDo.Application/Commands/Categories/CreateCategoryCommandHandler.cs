using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Extensions;
using TestToDo.Contracts.DTOs;
using TestToDo.Entities;
using TestToDo.Interfaces;

namespace TestToDo.Application.Commands.Categories;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICurrentUserProvider currentUser) : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var c = await categoryRepository.GetCategoryByNameAsync(request.CategoryName, currentUser.GetUserId() , cancellationToken);
        if (c != null) throw new ArgumentException($"Category with name {request.CategoryName} already exists");
        
        c = Category.Create(request.CategoryName, currentUser.GetUserId() );
        await categoryRepository.AddCategoryAsync(c, cancellationToken);
        await categoryRepository.SaveChangesAsync(cancellationToken);
        return c.ToDto();
    }
}