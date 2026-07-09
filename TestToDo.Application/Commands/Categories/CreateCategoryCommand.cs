using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Commands.Categories;

public readonly record struct CreateCategoryCommand(string CategoryName) : IRequest<CategoryDto>;