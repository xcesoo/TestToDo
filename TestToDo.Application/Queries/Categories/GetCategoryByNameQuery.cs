using MediatR;
using TestToDo.Contracts.DTOs;

namespace TestToDo.Application.Queries.Categories;

public readonly record struct GetCategoryByNameQuery(string CategoryName) :  IRequest<CategoryDto?>;