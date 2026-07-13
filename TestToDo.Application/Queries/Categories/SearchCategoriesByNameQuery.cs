using MediatR;
using TestToDo.Contracts.DTOs;

namespace TestToDo.Application.Queries.Categories;

public readonly record struct SearchCategoriesByNameQuery(string CategoryName) :  IRequest<IReadOnlyCollection<CategoryDto>>;