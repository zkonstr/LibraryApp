﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
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

        public IEnumerable<UserDTO> GetAllUsers(bool trackChanges)
        {
            var users = _repository.User.GetAllUsers(trackChanges);
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
            return usersDto;
        }

        public UserDTO GetUser(Guid id, bool trackChanges)
        {
            var user = _repository.User.GetUser(id, trackChanges);
            if (user is null)
                throw new UserNotFoundException(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public UserDTO CreateUser(UserForCreationDTO user)
        {
            var UserEntity = _mapper.Map<User>(user);
            _repository.User.CreateUser(UserEntity);
            _repository.Save();
            var UserToReturn = _mapper.Map<UserDTO>(UserEntity);
            return UserToReturn;
        }

        public void DeleteUser(Guid id,bool trackChanges)
        {
            var user = _repository.User.GetUser(id, trackChanges);
            if (user is null)
                throw new UserNotFoundException(id);
            _repository.User.DeleteUser(user);
            _repository.Save();
        }

        public void UpdateUser(Guid id, UserForUpdateDTO userForUpdate, bool trackChanges)
        {
            var userEntity = _repository.User.GetUser(id, trackChanges);
            if (userEntity is null)
                throw new UserNotFoundException(id);
            _mapper.Map(userForUpdate, userEntity);
            _repository.Save();
        }
    }
}
