using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookUserReferenceRepository : RepositoryBase<BookUserReference>, IBookUserReferenceRepository
    {
        public BookUserReferenceRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public void CreateBookUserReference(BookUserReference bookUserReference) => Create(bookUserReference);

        public async Task<IEnumerable<BookUserReference>> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(b => ids.Contains(b.Id), trackChanges).ToListAsync();

        public async Task<IEnumerable<BookUserReference>> GetAllBookUserReferences(bool trackChanges) =>await FindAll(trackChanges).OrderBy(c => c.OrderDate).ToListAsync();

        public async Task<BookUserReference> GetBookUserReference(Guid Id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();

        public void DeleteBookUserReference(BookUserReference bookUserReference) => Delete(bookUserReference);

        public void UpdateBookUserReference(BookUserReference bookUserReference)
        {
            throw new NotImplementedException();
        }
    }
}
