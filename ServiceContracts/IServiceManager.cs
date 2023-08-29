using ServiceContracts;

namespace ServiceContracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IBookService BookService { get; }
    }
}
