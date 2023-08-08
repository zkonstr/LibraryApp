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
        Task<IEnumerable<BookUserReferenceDTO>> GetAllBookUserReferencesAsync(bool trackChanges);

        Task<BookUserReferenceDTO> GetBookUserReferenceAsync(Guid id, bool trackChanges);

        Task<BookUserReferenceDTO> CreateBookUserReferenceAsync(BookUserReferenceForCreationDTO bookUserReference, bool trackChanges);

        Task UpdateBookUserReferenceAsync(Guid bookUserReferenceId, BookUserReferenceForUpdateDTO bookUserReferenceForUpdate, bool trackChanges);

        Task DeleteBookUserReferenceAsync(Guid bookUserReferenceId, bool trackChanges);
    }
}
