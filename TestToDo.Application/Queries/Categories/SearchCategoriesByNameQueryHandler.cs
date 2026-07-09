using System.Collections.ObjectModel;
using MediatR;
using TestToDo.Application.DTOs;
using TestToDo.Application.Mappings;
using TestToDo.Interfaces;

namespace TestToDo.Application.Queries.Categories;

public class SearchCategoriesByNameQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<SearchCategoriesByNameQuery, IReadOnlyCollection<CategoryDto>>
{
    public async Task<IReadOnlyCollection<CategoryDto>> Handle(SearchCategoriesByNameQuery request, CancellationToken cancellationToken)
    {
        var ct = await categoryRepository.SearchCategoriesByName(request.CategoryName, cancellationToken);
        return ct.ToDtoCollection();
    }
}