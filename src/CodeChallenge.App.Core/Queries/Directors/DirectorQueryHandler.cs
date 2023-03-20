using MediatR;
using CodeChallenge.App.Core.Dto;
using CodeChallenge.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Queries.Directors
{
    public class DirectorQueryHandler : IRequestHandler<GetDirectorByIdQuery, Director_DTO>,
        IRequestHandler<GetDirectorsAllQuery, IEnumerable<Director_DTO>>
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorQueryHandler(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }
        public async Task<Director_DTO> Handle(GetDirectorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _directorRepository.GetDirectorById(request.Id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Director_DTO>> Handle(GetDirectorsAllQuery request, CancellationToken cancellationToken)
        {
            return await _directorRepository.GetDirectorsAll().ConfigureAwait(false);
        }
    }
}
