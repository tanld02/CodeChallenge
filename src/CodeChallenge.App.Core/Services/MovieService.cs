using CodeChallenge.App.Core.Dto;
using CodeChallenge.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Movie_DTO> CreateMovie(Movie_DTO movie_DTO)
        {
            var result = await _unitOfWork.MovieRepository.CreateMovie(movie_DTO).ConfigureAwait(false);

            if (result == null)
            {
                throw new Exception();
            }
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return movie_DTO;
        }

        public async Task<Guid> DeleteMovie(Guid movieId)
        {
            var result = await _unitOfWork.MovieRepository.DeleteMovie(movieId).ConfigureAwait(false);
            if (result == Guid.Empty)
            {
                throw new Exception();
            }
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<Movie_DTO> UpdateMovie(Movie_DTO movie_DTO)
        {
            var result = await _unitOfWork.MovieRepository.UpdateMovie(movie_DTO).ConfigureAwait(false);

            if (result == null)
            {
                throw new Exception();
            }
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return movie_DTO;
        }
    }
}
