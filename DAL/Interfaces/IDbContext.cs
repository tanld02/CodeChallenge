using CodeChallenge.Models.DAO;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.DAL.Interfaces
{
    public interface IDbContext
    {
        /// <summary>
        /// Asynchronously saves the changes to DB.
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
        /// <summary>
        /// Context will not track entities. This will increase performance for readonly scenarios.
        /// </summary>
        void SetAsNoTracking();
        /// <summary>
        /// Map model of <typeparamref name="T"/> to table in database
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <returns></returns>
        DbSet<T> GetSet<T>() where T : class;

        DbSet<Movie> Movies { get; set; }
        DbSet<Director> Directors { get; set; }
    }
}
