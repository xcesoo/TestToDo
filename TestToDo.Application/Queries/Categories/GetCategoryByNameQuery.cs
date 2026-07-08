using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.Categories;

public record GetCategoryByNameQuery(string CategoryName) :  IRequest<IReadOnlyCollection<CategoryDto>>;