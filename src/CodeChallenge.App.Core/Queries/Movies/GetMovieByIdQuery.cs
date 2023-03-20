using MediatR;
using CodeChallenge.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Queries.Movies
{
    public class GetMovieByIdQuery : IRequest<Movie_DTO>
    {
        public Guid Id { get; set; }
    }
}
