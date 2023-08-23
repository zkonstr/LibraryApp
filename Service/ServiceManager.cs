using AutoMapper;
using Contracts;
using ServiceContracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager

    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IBookUserReferenceService> _bookUserReferenceService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() =>
            new UserService(repositoryManager,mapper));
            _bookService = new Lazy<IBookService>(() =>
            new BookService(repositoryManager, mapper));
            _bookUserReferenceService = new Lazy<IBookUserReferenceService>(() =>
            new BookUserReferenceService(repositoryManager, mapper));
        }

        public IUserService UserService => _userService.Value;
        public IBookService BookService => _bookService.Value;
        public IBookUserReferenceService BookUserReferenceServise => _bookUserReferenceService.Value;
    }
}
