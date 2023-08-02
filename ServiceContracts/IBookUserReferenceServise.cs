using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IBookUserReferenceServise
    {
        Task<IEnumerable<BookUserReferenceDTO>> GetAllBookUserReferences(Guid userId, bool trackChanges);

        Task<BookUserReferenceDTO> GetBookUserReference(string bookId, bool trackChanges);

        Task<BookUserReferenceDTO> CreateBookUserReference(BookUserReferenceForCreationDTO bookUserReference);

        Task UpdateBookUserReference(Guid bookUserReferenceId, BookUserReferenceForUpdateDTO bookUserReferenceForUpdate, bool trackChanges);

        Task DeleteBookUserReference(Guid bookUserReferenceId, bool trackChanges);
    }
}
