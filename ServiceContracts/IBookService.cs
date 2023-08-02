using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooks(bool trackChanges);

        Task<BookDTO> GetBook(Guid id, bool trackChanges);

        Task<BookDTO> CreateBook(BookForCreationDTO book);

        Task UpdateBook(Guid bookId, BookForUpdateDTO bookForUpdate, bool trackChanges);

        Task DeleteBook(Guid bookId, bool trackChanges);
    }
}
