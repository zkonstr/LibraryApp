namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IBookRepository Book { get; }
        Task SaveAsync();
    }
}
