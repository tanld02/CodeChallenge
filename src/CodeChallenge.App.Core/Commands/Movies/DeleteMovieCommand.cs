using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Commands.Movies
{
    public class DeleteMovieCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
