using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync(bool trackChanges);

        Task<UserDTO> GetUserAsync(Guid id, bool trackChanges);

        Task<UserDTO> CreateUserAsync(UserForCreationDTO user);

        Task UpdateUserAsync(Guid userId,UserForUpdateDTO userForUpdate,bool trackChanges);

        Task DeleteUserAsync(Guid userId,bool trackChanges);

    }
}
