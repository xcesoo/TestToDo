using MediatR;
using TestToDo.Application.DTOs;

namespace TestToDo.Application.Commands.Categories;

public record CreateCategoryCommand(string CategoryName) : IRequest<CategoryDto>;