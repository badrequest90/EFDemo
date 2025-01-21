public interface IUserService
{
    Task<PaginatedResponse<DetailsUserDTO>> GetAllAsync(PaginationRequestDTO request);
    Task<DetailsUserDTO> GetByIdAsync(Guid id);
    Task<User> AddAsync(CreateUserDTO entity);
    Task<bool> UpdateAsync(CreateUserDTO entity, Guid id);
    Task<bool> DeleteAsync(Guid id);
}
