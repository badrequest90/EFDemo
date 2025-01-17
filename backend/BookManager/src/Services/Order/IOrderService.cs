public interface IOrderService
{
    Task<PaginatedResponse<DetailsOrderDTO>> GetAllAsync(PaginationRequestDTO request);
    Task<DetailsOrderDTO> GetByIdAsync(Guid id);
    Task<Order> AddAsync(CreateOrderDTO entity);
    Task<bool> UpdateAsync(CreateOrderDTO entity, Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task AddOrderItemAsync(CreateOrderItemDTO entity, Guid id);
    Task<bool> UpdateOrderItemAsync(CreateOrderItemDTO entity, Guid id);
    Task<bool> DeleteOrderItemAsync(Guid id);
}