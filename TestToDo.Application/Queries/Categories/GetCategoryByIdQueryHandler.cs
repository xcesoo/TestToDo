using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Mappings;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.Categories;

public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, ICurrentUserProvider currentUser) : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.GetCategoryByIdAsync(request.Id, currentUser.GetUserId(), cancellationToken);
        return ct?.ToDto();
    }
}