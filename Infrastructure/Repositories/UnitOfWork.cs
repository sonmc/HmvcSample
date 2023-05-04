
using HmvcSample.Infrastructure;
using HmvcSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Kidsenglish.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dbContext;

        public IUserRepository UserRepository { get; }

        public UnitOfWork(DataContext _dbContext,
                          IUserRepository userRepository
                          )
        {
            this.dbContext = _dbContext;
            this.UserRepository = userRepository;
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return this.dbContext.Database.CreateExecutionStrategy();
        }

        public IDbContextTransaction BeginTransaction()
        {
            IDbContextTransaction dbContextTransaction = this.dbContext.Database.BeginTransaction();
            return dbContextTransaction;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dbContext.Dispose();
            }
        }
    }
}

