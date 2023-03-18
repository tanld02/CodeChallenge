﻿using CodeChallenge.Models.DAO;
using CodeChallenge.Models.DTO;

namespace CodeChallenge.DAL.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie_DTO>> GetMoviesAll();
        Task<Movie_DTO> GetMovieById(Guid movieId);
        Task<IEnumerable<Movie_DTO>> GetMoviesByDirectorId(Guid directorId);
        Task<IEnumerable<Movie_DTO>> GetMoviesByDirectorName(string directorName);
    }
}
