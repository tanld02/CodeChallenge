using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RWE.App.Core.Dto;
using RWE.App.Core.Interfaces;

namespace RWE.App.Core.Commands.Directors
{
    public class DirectorCommandHandler : IRequestHandler<CreateDirectorCommand, Director_DTO>,
        IRequestHandler<UpdateDirectorCommand, Director_DTO>,
        IRequestHandler<DeleteDirectorCommand, Guid>
    {
        private readonly IDirectorService _directorService;

        public DirectorCommandHandler(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        public async Task<Director_DTO> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            return await _directorService.UpdateDirector(request.Dto).ConfigureAwait(false);
        }

        public async Task<Guid> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            return await _directorService.DeleteDirector(request.Id).ConfigureAwait(false);
        }

        public async Task<Director_DTO> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            return await _directorService.CreateDirector(request.Dto).ConfigureAwait(false);
        }
    }
}
