using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.Categories;

public readonly record struct GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto?>;