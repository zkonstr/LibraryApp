using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBookUserReferenceRepository
    {
        Task<IEnumerable<BookUserReference>> GetAllBookUserReferences(bool trackChanges);
        Task<IEnumerable<BookUserReference>> GetByIds( IEnumerable<Guid> ids, bool trackChanges);
        Task<BookUserReference> GetBookUserReference( Guid Id, bool trackChanges);
        void CreateBookUserReference(BookUserReference bookUserReference);
        void DeleteBookUserReference(BookUserReference bookUserReference);
    }
}
