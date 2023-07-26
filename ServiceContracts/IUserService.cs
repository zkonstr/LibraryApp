using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers(bool trackChanges);

        UserDTO GetUser(Guid id, bool trackChanges);

        UserDTO CreateUser(UserForCreationDTO user);

        void UpdateUser(Guid userId,UserForUpdateDTO userForUpdate,bool trackChanges);

        void DeleteUser(Guid userId,bool trackChanges);

    }
}
