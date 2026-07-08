using TestToDo.Application.DTOs;
using TestToDo.Entities;

namespace TestToDo.Application.Mappings;

public static class CategoryMappingExtensions
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(
            Id: category.Id,
            Name: category.Name);
    }

    public static IReadOnlyCollection<CategoryDto> ToDtoCollection(this IEnumerable<Category> categories)
    {
        return categories.Select(c => c.ToDto()).ToArray();
    }
}