using MediatR;

namespace TestToDo.Application.Commands.Categories;

public readonly record struct ChangeCategoryNameCommand(Guid CategoryId, string NewName) : IRequest;