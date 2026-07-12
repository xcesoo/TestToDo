using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Extensions;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.Categories;

public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, ICurrentUserProvider currentUser)
    : IRequestHandler<GetAllCategoriesQuery, IReadOnlyCollection<CategoryDto>>
{
    public async Task<IReadOnlyCollection<CategoryDto>> Handle(GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.GetCategoriesAsync(currentUser.GetUserId(),cancellationToken);
        return ct.ToDtoCollection();
    }
}