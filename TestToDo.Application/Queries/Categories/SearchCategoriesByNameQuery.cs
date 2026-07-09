using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.Categories;

public readonly record struct SearchCategoriesByNameQuery(string CategoryName) :  IRequest<IReadOnlyCollection<CategoryDto>>;