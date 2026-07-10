using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Mappings;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.Categories;

public class GetCategoryByNameQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByNameQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.GetCategoryByNameAsync(request.CategoryName, cancellationToken);
        return ct?.ToDto();
    }
}