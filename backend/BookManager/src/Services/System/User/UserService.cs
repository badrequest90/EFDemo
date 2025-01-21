
public class UserService : IUserService
{
    private BookManagerContext _context;
    private CryptographyOptions _cryptographicOptions;
    public UserService(BookManagerContext context, CryptographyOptions cryptographyOptions)
    {
        _context = context;
        _cryptographicOptions = cryptographyOptions;
    }

    public async Task<User> AddAsync(CreateUserDTO entity)
    {
        await _context.User.Add(new User{
            ArgonIterations = _cryptographicOptions.
        })
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponse<DetailsUserDTO>> GetAllAsync(PaginationRequestDTO request)
    {
        throw new NotImplementedException();
    }

    public Task<DetailsUserDTO> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(CreateUserDTO entity, Guid id)
    {
        throw new NotImplementedException();
    }

    // Add or override custom methods specific to User here
}
