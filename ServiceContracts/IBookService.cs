using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync(bool trackChanges);

        Task<BookDTO> GetBookAsync(Guid id, bool trackChanges);
        Task<BookDTO> GetBookByISBNAsync(string ISBN, bool trackChanges);

        Task<BookDTO> CreateBookAsync(BookForCreationDTO book);

        Task UpdateBookAsync(Guid bookId, BookForUpdateDTO bookForUpdate, bool trackChanges);

        Task DeleteBookAsync(Guid bookId, bool trackChanges);
    }
}
