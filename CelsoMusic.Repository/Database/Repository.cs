using CelsoMusic.Infra.Repository;
using CelsoMusic.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace CelsoMusic.Repository.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(CelsoMusicContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<IDbContextTransaction> CreateTransaction()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> CreateTransaction(IsolationLevel isolation)
        {
            return await Context.Database.BeginTransactionAsync(isolation);
        }

        public async Task Delete(T entity)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> Get(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet
                            .AsNoTrackingWithIdentityResolution()
                            .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByCriteria(Expression<Func<T, bool>> expresssion)
        {
            return await DbSet
                            .AsNoTrackingWithIdentityResolution()
                            .Where(expresssion)
                            .ToListAsync();
        }

        public async Task<T> GetOneByCriteria(Expression<Func<T, bool>> expresssion)
        {
            return await DbSet
                            .AsNoTrackingWithIdentityResolution()
                            .FirstOrDefaultAsync(expresssion);
        }

        public async Task Save(T entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
