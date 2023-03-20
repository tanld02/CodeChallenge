using MediatR;
using CodeChallenge.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Commands.Movies
{

    public class UpdateMovieCommand : IRequest<Movie_DTO>
    {
        public Movie_DTO Dto { get; set; }
    }
}
