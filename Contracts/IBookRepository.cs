using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks(bool trackChanges);
        Task<IEnumerable<Book>> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        Task<Book> GetBook(Guid Id, bool trackChanges);
        Task<Book> GetBookByISBN(string ISBN, bool trackChanges);
        void CreateBook(Book book);
        void DeleteBook(Book book);
    }
}
