using MediatR;
using TestToDo.Contracts.DTOs;

namespace TestToDo.Application.Queries.Categories;

public readonly record struct GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto?>;