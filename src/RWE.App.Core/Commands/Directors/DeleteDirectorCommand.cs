using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RWE.App.Core.Dto;

namespace RWE.App.Core.Commands.Directors
{
    public class DeleteDirectorCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
