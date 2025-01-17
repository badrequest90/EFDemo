public class DetailsOrderDTO
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public DateTime OrderDate { get; init; }
    public Decimal TotalPrice { get; init; }
    public OrderStatus OrderStatus { get; init; }
    public List<DetailsOrderItemDTO> OrderItemsId { get; init; }
}