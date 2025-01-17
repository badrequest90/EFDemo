public class PaginatedResponse<T>
{
    public IEnumerable<T> Items { get; init; }
    public int TotalCount { get; init; }
    public int PageSize { get; init; }
    public int CurrentPage { get; init; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}