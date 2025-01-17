public interface IUserService
{
    Task<PaginatedResponse<DetaislAuthorDTO>> GetAllAsync(PaginationRequestDTO request);
    Task<DetaislAuthorDTO> GetByIdAsync(Guid id);
    Task<Author> AddAsync(CreateUserDTO entity);
    Task<bool> UpdateAsync(CreateUserDTO entity, Guid id);
    Task<bool> DeleteAsync(Guid id);
}
