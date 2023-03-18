using CodeChallenge.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CodeChallenge.DAL
{
    /// <summary>
    /// Generic repository for retrieving and modifying data from SqlStorage
    /// </summary>
    /// <typeparam name="T">Mapping class type related to existing table</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> table;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(IDbContext context)
        {
            table = context.GetSet<T>();
        }

        public T Create(T entity)
        {
            table.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            table.Update(entity);
            return entity;
        }

        public async Task<T> GetByIdAsync(Guid? uuid)
        {
            return await table.FindAsync(uuid);
        }

        public async Task<T> GetByIdWithIncludes(Guid? uuid, Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            var keyProperty = table.EntityType.FindPrimaryKey().Properties[0];
            IQueryable<T> query = table;
            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(qt => EF.Property<Guid>(qt, keyProperty.Name) == uuid);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public void BulkDelete(IEnumerable<T> entities)
        {
            table.RemoveRange(entities);
        }
    }
}
