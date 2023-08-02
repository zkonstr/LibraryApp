using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class BookUserReferenceServise : IBookUserReferenceServise
    {
        public BookUserReferenceDTO CreateBookUserReference(BookUserReferenceForCreationDTO bookUserReference)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookUserReference(Guid bookUserReferenceId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookUserReferenceDTO> GetAllBookUserReferences(Guid userId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public BookUserReferenceDTO GetBookUserReference(string bookISBN, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookUserReference(Guid bookUserReferenceId, BookUserReferenceForUpdateDTO bookUserReferenceForUpdate, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
