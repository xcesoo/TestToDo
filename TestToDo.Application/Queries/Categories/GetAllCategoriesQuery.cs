using MediatR;

namespace TestToDo.Application.Queries.Categories;

public readonly record struct GetAllCategoriesQuery() : IRequest; //todo pagination