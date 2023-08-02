﻿namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IBookRepository Book { get; }
        IBookUserReferenceRepository BookUserReference { get; }
        Task SaveAsync();
    }
}
