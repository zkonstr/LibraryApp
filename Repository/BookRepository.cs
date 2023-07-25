using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateBook(Book book) => Create(book);

        public IEnumerable<Book> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(u => ids.Contains(u.Id), trackChanges).ToList();

        public IEnumerable<Book> GetAllBooks(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.ISBN).ToList();

        public Book GetBook(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefault();

        public void DeleteBook(Book book) => Delete(book);

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
