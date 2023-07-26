using AutoMapper;
using Contracts;
using ServiceContracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager

    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() =>
            new UserService(repositoryManager,mapper));
            _bookService = new Lazy<IBookService>(() =>
            new BookService(repositoryManager, mapper));
        }

        public IUserService UserService => _userService.Value;
        public IBookService BookService => _bookService.Value;
    }
}
