using CodeChallenge.DAL.Interfaces;
using CodeChallenge.Models.DAO;
using CodeChallenge.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.DAL
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly IDbContext _context;

        public MovieRepository(IDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie_DTO>> GetMoviesAll()
        {
            return await _context.Movies
                .Select(c => new Movie_DTO()
                {
                    Uuid = c.Uuid,
                    Title = c.Title,
                    ReleaseDate = c.ReleaseDate,
                    Rating = c.Rating
                })
                .ToListAsync();
        }

        public async Task<Movie_DTO> GetMovieById(Guid movieId)
        {
            return await _context.Movies
                .Where(c => c.Uuid == movieId)
                .Select(c => new Movie_DTO()
                {
                    Uuid = c.Uuid,
                    Title = c.Title,
                    ReleaseDate = c.ReleaseDate,
                    Rating = c.Rating
                })
                .FirstOrDefaultAsync();
        }
    }
}
