using MediatR;
using TestToDo.Application.Interfaces;
using TestToDo.Application.Extensions;
using TestToDo.Contracts.DTOs;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.Categories;

public class SearchCategoriesByNameQueryHandler(ICategoryRepository categoryRepository, ICurrentUserProvider currentUser) : IRequestHandler<SearchCategoriesByNameQuery, IReadOnlyCollection<CategoryDto>>
{
    public async Task<IReadOnlyCollection<CategoryDto>> Handle(SearchCategoriesByNameQuery request, CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.SearchCategoriesByNameAsync(request.CategoryName,currentUser.GetUserId(), cancellationToken);
        return ct.ToDtoCollection();
    }
}