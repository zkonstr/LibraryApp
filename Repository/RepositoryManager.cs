using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IBookUserReferenceRepository> _bookUserReferenceRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new
            UserRepository(repositoryContext));

            _repositoryContext = repositoryContext;
            _bookRepository = new Lazy<IBookRepository>(() => new
            BookRepository(repositoryContext));

            _repositoryContext = repositoryContext;
            _bookUserReferenceRepository = new Lazy<IBookUserReferenceRepository>(() => new
            BookUserReferenceRepository(repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IBookRepository Book => _bookRepository.Value;
        public IBookUserReferenceRepository BookUserReference => _bookUserReferenceRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }

}
