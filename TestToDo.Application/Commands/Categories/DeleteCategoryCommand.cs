using MediatR;

namespace TestToDo.Application.Commands.Categories;

public readonly record struct DeleteCategoryCommand(Guid CategoryId) : IRequest;