public class DetailsCategoryDTO : CreateCategoryDTO{
    public Guid Id {get;init;}
    public List<DetailsBooksCategoryDTO> Books {get;init;}
}

public class DetailsBooksCategoryDTO{
    public Guid Id {get;init;}
    public string Title {get;init;}
}