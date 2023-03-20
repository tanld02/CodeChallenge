using RWE.App.Core.Interfaces;
using RWE.App.Core.Dto;
using RWE.App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RWE.App.Infrastructure.Repository;

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
            .AsNoTracking()
            .Include(m => m.Uu)
            .Select(c => new Movie_DTO()
            {
                Uuid = c.Uuid,
                Title = c.Title,
                ReleaseDate = c.ReleaseDate,
                Rating = c.Rating,
                DirectorId = c.DirectorUuid
            })
            .ToListAsync();
    }

    public async Task<Movie_DTO> GetMovieById(Guid movieId)
    {
        return await _context.Movies.
            AsNoTracking()
            .Where(c => c.Uuid == movieId)?
            .Select(c => new Movie_DTO()
            {
                Uuid = c.Uuid,
                Title = c.Title,
                ReleaseDate = c.ReleaseDate,
                Rating = c.Rating,
                DirectorId = c.DirectorUuid
            })?
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Movie_DTO>> GetMoviesByDirectorId(Guid directorId)
    {
        return await _context.Movies
            .Where(c => c.DirectorUuid == directorId)
            .Select(c => new Movie_DTO()
            {
                Uuid = c.Uuid,
                Title = c.Title,
                ReleaseDate = c.ReleaseDate,
                Rating = c.Rating,
                DirectorId = c.DirectorUuid
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<Movie_DTO>> GetMoviesByDirectorName(string directorName)
    {
        return await (from director in _context.Directors
                      where director.Name == directorName
                      join movie in _context.Movies on director.Uuid equals movie.DirectorUuid
                      select new Movie_DTO()
                      {
                          Uuid = movie.Uuid,
                          Title = movie.Title,
                          ReleaseDate = movie.ReleaseDate,
                          Rating = movie.Rating,
                          DirectorId= movie.DirectorUuid
                      })
         .ToListAsync();
    }

    public async Task<Movie_DTO> UpdateMovie(Movie_DTO data)
    {

        var result = _context.Movies.Update(new Movie()
        {
            Rating = data.Rating,
            ReleaseDate = data.ReleaseDate,
            Title = data.Title,
            DirectorUuid = data.DirectorId,
            Uuid = data.Uuid
        });

        if (result != null)
        {
            return data;
        }
        else
        {
            throw new Exception();
        }
    }

    public async Task<Guid> DeleteMovie(Guid movieId)
    {
        var result = await Task.FromResult(_context.Movies.Remove(new Movie() { Uuid = movieId }));

        if (result != null)
        {
            return result.Entity.Uuid;
        }
        else
        {
            throw new NullReferenceException();
        };
    }
}
