using System;
using HmvcSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Kidsenglish.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        int SaveChanges();
        Task SaveChangesAsync();
        IExecutionStrategy CreateExecutionStrategy();
        IDbContextTransaction BeginTransaction();
    }
}

