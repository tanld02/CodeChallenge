using MediatR;
using RWE.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.App.Core.Queries.Movies
{
    public class GetMoviesAllQuery : IRequest<IEnumerable<Movie_DTO>>
    {
    }
}
