

using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    protected readonly BookManagerContext _context;

    public OrderService(BookManagerContext context)
    {
        _context = context;
    }

    public async Task<Order> AddAsync(CreateOrderDTO entity)
    {   
        var bookIds = entity.OrderItems.Select(oi => oi.BookId).ToList();

        var bookPriceDict = await _context.BookPrices
            .Where(bp => bp.ValidFrom <= DateTime.Now && bookIds.Contains(bp.BookId))
            .OrderByDescending(bp => bp.ValidFrom)
            .GroupBy(bp => bp.BookId)
            .ToDictionaryAsync(g => g.Key, g => g.FirstOrDefault());

        var books = await _context.Books.Where(b => bookIds.Contains(b.Id)).ToListAsync();

        foreach (var book in books)
        {
            var orderQuantity = entity.OrderItems.First(x => x.BookId == book.Id).quantity;
            if (book.Stock < orderQuantity)
            {
                throw new InvalidOperationException($"Insufficient stock for book: {book.Title}");
            }
            book.Stock -= orderQuantity;
        }

        var order = new Order
        {
            CustomerId = Guid.NewGuid(),
            OrderDate = DateTime.Now,
            OrderItems = entity.OrderItems.Select(o => new OrderItem
            {
                BookId = o.BookId,
                ItemPrice = bookPriceDict.TryGetValue(o.BookId, out var price) ? price.Price : 0,
                Quantity = o.quantity
            }).ToList()
        };

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }

        return order;
    }

    public Task AddOrderItemAsync(CreateOrderItemDTO entity, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOrderItemAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedResponse<DetailsOrderDTO>> GetAllAsync(PaginationRequestDTO request)
    {
        return await _context.Orders
                .Include(x => x.OrderItems)
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.UpdatedAt)
                .Select(c => new DetailsOrderDTO
                {
                    CustomerId = c.CustomerId,
                    OrderDate = c.OrderDate,
                    OrderStatus = c.OrderStatus,
                    TotalPrice = c.TotalPrice
                }).ToPaginatedResponseAsync(request);
    }

    public Task<DetailsOrderDTO> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(CreateOrderDTO entity, Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateOrderItemAsync(CreateOrderItemDTO entity, Guid id)
    {
        throw new NotImplementedException();
    }
}