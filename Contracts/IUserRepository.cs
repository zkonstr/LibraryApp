using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<User> GetUserAsync(Guid Id, bool trackChanges);
        void CreateUser(User user);
        void DeleteUser(User user);
    }
}
