using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        	_userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequestDTO request)
    {
        var results = await _userService.GetAllAsync(request);
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneById(Guid id)
    {
        var result = await _userService.GetByIdAsync(id);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserDTO model)
    {
        var entity = await _userService.AddAsync(model);
        return CreatedAtAction(nameof(GetOneById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateUserDTO model)
    {
        var success = await _userService.UpdateAsync(model, id);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _userService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}