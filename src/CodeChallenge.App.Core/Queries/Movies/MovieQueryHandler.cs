using MediatR;
using CodeChallenge.App.Core.Dto;
using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Core.Queries.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Queries.Directors
{
    public class MovieQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie_DTO>,
        IRequestHandler<GetMoviesByDirectorIdQuery, IEnumerable<Movie_DTO>>,
        IRequestHandler<GetMoviesByDirectorNameQuery, IEnumerable<Movie_DTO>>,
        IRequestHandler<GetMoviesAllQuery, IEnumerable<Movie_DTO>>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }    
        public async Task<Movie_DTO> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.GetMovieById(request.Id).ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Movie_DTO>> Handle(GetMoviesByDirectorIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.GetMoviesByDirectorId(request.DirectorId).ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Movie_DTO>> Handle(GetMoviesAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.GetMoviesAll().ConfigureAwait(false);
            return result;
        }

        public async Task<IEnumerable<Movie_DTO>> Handle(GetMoviesByDirectorNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _movieRepository.GetMoviesByDirectorName(request.DirectorName).ConfigureAwait(false);
            return result;
        }
    }
}
