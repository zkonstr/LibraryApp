using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class UserService : IUserService
    {

        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            //_logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await _repository.User.GetAllUsersAsync(trackChanges);
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDto;
        }

        public async Task<UserDTO> GetUserAsync(Guid id, bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(id, trackChanges);
            if (user is null)
                throw new UserNotFoundException(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public async Task<UserDTO> CreateUserAsync(UserForCreationDTO user)
        {
            var UserEntity = _mapper.Map<User>(user);
            _repository.User.CreateUser(UserEntity);
            await _repository.SaveAsync();
            var UserToReturn = _mapper.Map<UserDTO>(UserEntity);
            return UserToReturn;
        }

        public async Task DeleteUserAsync(Guid id,bool trackChanges)
        {
            var user = await _repository.User.GetUserAsync(id, trackChanges);
            if (user is null)
                throw new UserNotFoundException(id);
            _repository.User.DeleteUser(user);
            await _repository.SaveAsync();
        }

        public async Task UpdateUserAsync(Guid id, UserForUpdateDTO userForUpdate, bool trackChanges)
        {
            var userEntity = await _repository.User.GetUserAsync(id, trackChanges);
            if (userEntity is null)
                throw new UserNotFoundException(id);
            _mapper.Map(userForUpdate, userEntity);
            await _repository.SaveAsync();
        }
    }
}
