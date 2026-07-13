namespace TestToDo.Filters;

public readonly record struct PaginationFilter
{
    public int Page { get; }
    public int PageSize { get; }

    public PaginationFilter(int page, int pageSize)
    {
        Page = page < 1 ? 1 : page;
        PageSize = pageSize > 366 ? 366 : (pageSize < 1 ? 1 : pageSize);
    }
}