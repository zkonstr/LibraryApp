using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            //_logger = logger;
            _mapper = mapper;
        }
        
        public IEnumerable<BookDTO> GetAllBooks(bool trackChanges)
        {
            var books = _repository.Book.GetAllBooks(trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDTO>>(books);
            return booksDto;
        }

        public BookDTO GetBook(Guid id, bool trackChanges)
        {
            var book = _repository.Book.GetBook(id, trackChanges);
            if (book is null)
                throw new BookNotFoundException(id);
            var bookDto = _mapper.Map<BookDTO>(book);
            return bookDto;
        }

        public BookDTO CreateBook(BookForCreationDTO book)
        {
            var BookEntity = _mapper.Map<Book>(book);
            _repository.Book.CreateBook(BookEntity);
            _repository.Save();
            var BookToReturn = _mapper.Map<BookDTO>(BookEntity);
            return BookToReturn;
        }

        public void DeleteBook(Guid id, bool trackChanges)
        {
            var book = _repository.Book.GetBook(id, trackChanges);
            if (book is null)
                throw new BookNotFoundException(id);
            _repository.Book.DeleteBook(book);
            _repository.Save();
        }

        public void UpdateBook(Guid id, BookForUpdateDTO bookForUpdate, bool trackChanges)
        {
            var bookEntity = _repository.Book.GetBook(id, trackChanges);
            if (bookEntity is null)
                throw new BookNotFoundException(id);
            _mapper.Map(bookForUpdate, bookEntity);
            _repository.Save();
        }

    }
}
