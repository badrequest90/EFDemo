public class DetailsBookDTO
{    
    public Guid Id {get;init;}
    public string Title { get; init; }
    public DetailsAuthorBookDTO Author { get; init; }
    public string Description { get; init; }
    public string CoverImageUrl { get; init; }
    public DateTime PublishedAt { get; init; }
    public int Stock { get; init; }
    public List<string> Categories { get; init; }
    public Decimal Price { get; init; }
    public List<DetailsBookPriceDTO> BookPrices {get;init;}
}

public class DetailsAuthorBookDTO{
    public Guid Id {get;init;}
    public string Name {get;init;}
}