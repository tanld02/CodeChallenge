using MediatR;
using RWE.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.App.Core.Queries.Directors
{
    public class GetDirectorByIdQuery : IRequest<Director_DTO>
    {
        public Guid Id { get; set; }
    }
}
