public class DetaislAuthorDTO : CreateAuthorDTO
{
    public Guid Id { get; init; }
    public List<DetailsAuthorBooksDTO> Books {get;init;}
}

public class DetailsAuthorBooksDTO
{
    public Guid Id { get; init; }
    public string Title { get; init; }
}