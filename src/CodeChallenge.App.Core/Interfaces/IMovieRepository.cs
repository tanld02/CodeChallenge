using CodeChallenge.App.Core.Dto;
using CodeChallenge.App.Core.Entities;

namespace CodeChallenge.App.Core.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie_DTO>> GetMoviesAll();
        Task<Movie_DTO> GetMovieById(Guid movieId);
        Task<IEnumerable<Movie_DTO>> GetMoviesByDirectorId(Guid directorId);
        Task<IEnumerable<Movie_DTO>> GetMoviesByDirectorName(string directorName);
        Task<Movie_DTO> UpdateMovie(Movie_DTO data);
        Task<Movie_DTO> CreateMovie(Movie_DTO data);
        Task<Guid> DeleteMovie(Guid movieId);
    }
}
