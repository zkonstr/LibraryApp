using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks(bool trackChanges);

        BookDTO GetBook(Guid id, bool trackChanges);

        BookDTO CreateBook(BookForCreationDTO book);

        void UpdateBook(Guid bookId, BookForUpdateDTO bookForUpdate, bool trackChanges);

        void DeleteBook(Guid bookId, bool trackChanges);
    }
}
