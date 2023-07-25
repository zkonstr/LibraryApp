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
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        IEnumerable<Book> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        Book GetBook(Guid Id, bool trackChanges);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
