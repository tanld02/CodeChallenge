using Microsoft.EntityFrameworkCore.Query;

namespace CodeChallenge.DAL.Interfaces
{
    /// <summary>
    /// Generic repository interface for retrieving and modifying data from SqlStorage
    /// </summary>
    /// <typeparam name="T">Mapping class type related to existing table</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Create entity and begin tracking it. 
        /// Record is created after changes are saved with _context.SaveChangesAsync()
        /// </summary>
        /// <param name="entity">Reference to entity of type <typeparamref name="T"/></param>
        T Create(T entity);
        /// <summary>
        /// Being tracking entity. 
        /// This will not be reflected immediately but only after call to _context.SaveChangesAsync()
        /// </summary>
        /// <param name="entity">entity of type <typeparamref name="T"/></param>
        T Update(T entity);
        /// <summary>
        /// Asynchronously retrieve a single <typeparamref name="T"/> from database with the given primary key. If no <typeparamref name="T"/> found, returns null.
        /// </summary>
        /// <param name="uuid">The value of the primary key for the entity to be found</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid? uuid);
        /// <summary>
        /// Asynchronously retrieve a single <typeparamref name="T"/> from database with the given primary key with specific relation includes.
        /// </summary>
        /// <param name="uuid">The value of the primary key for the entity to be found</param>
        /// <param name="include">Specified includes to fetch</param>
        /// <returns></returns>
        Task<T> GetByIdWithIncludes(Guid? uuid, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        /// <summary>
        /// Asynchronously retrieve a list of <typeparamref name="T"/> from database.
        /// </summary>
        /// <returns>Returns a list of <typeparamref name="T"/></returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Put the entity in the deleted state
        /// </summary>
        /// <param name="entity">entity of type <typeparamref name="T"/></param>
        void Delete(T entity);

        void BulkDelete(IEnumerable<T> entities);
    }
}
