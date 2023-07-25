using ServiceContracts;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IBookService BookService { get; }
    }
}
