using CodeChallenge.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Interfaces
{
    public interface IMovieService
    {
        Task<Movie_DTO> CreateMovie(Movie_DTO movie_DTO);
        Task<Movie_DTO> UpdateMovie(Movie_DTO movie_DTO);
        Task<Guid> DeleteMovie(Guid directorId);
    }
}
