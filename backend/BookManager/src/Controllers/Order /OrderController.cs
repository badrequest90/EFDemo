using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequestDTO request)
    {
        var results = await _orderService.GetAllAsync(request);
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneById(Guid id)
    {
        var result = await _orderService.GetByIdAsync(id);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderDTO newOrder)
    {
        var entity = await _orderService.AddAsync(newOrder);
        return CreatedAtAction(nameof(GetOneById), new { id = entity.Id }, newOrder);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateOrderDTO order)
    {
        var success = await _orderService.UpdateAsync(order, id);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _orderService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}