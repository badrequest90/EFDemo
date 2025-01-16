public class CreateBookDTO()
{
    public string Title { get; init; }
    public Guid AuthorId { get; init; }
    public string Description { get; init; }
    public string CoverImageUrl { get; init; }
    public DateTime PublishedAt { get; init; }
    public int Stock { get; init; }
    public List<Guid> BookCategories { get; init; }
    public List<CreateBookPriceDTO> BookPrices { get; init; }
}