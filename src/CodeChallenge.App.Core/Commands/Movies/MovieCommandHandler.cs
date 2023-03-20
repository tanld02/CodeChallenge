using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.App.Core.Dto;
using CodeChallenge.App.Core.Interfaces;

namespace CodeChallenge.App.Core.Commands.Movies
{
    internal class MovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie_DTO>, 
        IRequestHandler<UpdateMovieCommand, Movie_DTO>,
        IRequestHandler<DeleteMovieCommand, Guid>
    {
        private readonly IMovieService _movieService;

        public MovieCommandHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<Movie_DTO> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieService.CreateMovie(request.Dto).ConfigureAwait(false);
        }

        public async Task<Movie_DTO> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieService.UpdateMovie(request.Dto).ConfigureAwait(false);
        }

        public async Task<Guid> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieService.DeleteMovie(request.Id).ConfigureAwait(false);
        }
    }
}
