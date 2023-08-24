using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
        {
        }
        public void CreateBook(Book book) => Create(book);

        public async Task<IEnumerable<Book>> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(b => ids.Contains(b.Id), trackChanges).ToListAsync();

        public async Task<IEnumerable<Book>> GetAllBooks(bool trackChanges) => await FindAll(trackChanges).OrderBy(c => c.ISBN).ToListAsync();

        public async Task<Book> GetBook(Guid Id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();


        public void DeleteBook(Book book) => Delete(book);

        public async Task<Book> GetBookByISBN(string ISBN, bool trackChanges) =>
            await FindByCondition(c => c.ISBN.Equals(ISBN), trackChanges).SingleOrDefaultAsync();
    }
}
