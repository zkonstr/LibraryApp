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
        IEnumerable<BookUserReference> GetAllBookUserReferences(Guid userId, bool trackChanges);
        IEnumerable<BookUserReference> GetByIds( IEnumerable<Guid> ids, bool trackChanges);
        BookUserReference GetBookUserReference(string bookISBN, Guid Id, bool trackChanges);
        void CreateBookUserReference(BookUserReference bookUserReference);
        void UpdateBookUserReference(BookUserReference bookUserReference);
        void DeleteBookUserReference(BookUserReference bookUserReference);
    }
}
