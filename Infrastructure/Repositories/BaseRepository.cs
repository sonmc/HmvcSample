using Microsoft.EntityFrameworkCore;

namespace HmvcSample.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        T Add(T entity);
        T Update(T entity);
        T Get(int id);
        T Delete(int id);
    }

    public abstract class BaseRepository<TEntity, TContext>
                 where TEntity : class
                 where TContext : DbContext
    {
        private readonly TContext context;
        public BaseRepository() { }
        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
