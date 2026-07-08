using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Queries.Categories;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto>;