using Contracts;
using Service.Contracts;
using ServiceContracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager

    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _userService = new Lazy<IUserService>(() =>
            new UserService(repositoryManager));
            _bookService = new Lazy<IBookService>(() => 
            new BookService(repositoryManager));
        }

        public IUserService UserService => _userService.Value;
        public IBookService BookService => _bookService.Value;
    }
}
