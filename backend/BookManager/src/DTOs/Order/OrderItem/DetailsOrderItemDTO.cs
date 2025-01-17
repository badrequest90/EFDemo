public class DetailsOrderItemDTO
{
    public Guid OrderItemId { get; init; }
    public Guid BookId { get; init; }
    public int Quantity { get; init; }
    public decimal ItemPrice { get; init; }
}