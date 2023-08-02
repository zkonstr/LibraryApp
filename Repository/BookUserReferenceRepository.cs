using Contracts;
using Entities.Models;
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

        public IEnumerable<BookUserReference> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(b => ids.Contains(b.Id), trackChanges).ToList();

        public IEnumerable<BookUserReference> GetAllBookUserReferences(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.OrderDate).ToList();

        public BookUserReference GetBookUserReference(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefault();

        public void DeleteBookUserReference(BookUserReference bookUserReference) => Delete(bookUserReference);

        public void UpdateBookUserReference(BookUserReference bookUserReference)
        {
            throw new NotImplementedException();
        }
    }
}
