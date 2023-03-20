using MediatR;
using RWE.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.App.Core.Commands.Movies
{
    public class CreateMovieCommand : IRequest<Movie_DTO>
    {
        public Movie_DTO Dto { get; set; }
    }
}
