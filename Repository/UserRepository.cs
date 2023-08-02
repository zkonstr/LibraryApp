using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public void CreateUser(User user) => Create(user);

        public async Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(u => ids.Contains(u.Id), trackChanges).ToListAsync();

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();

        public async Task<User> GetUserAsync(Guid Id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void DeleteUser(User user) => Delete(user);

    }
}
