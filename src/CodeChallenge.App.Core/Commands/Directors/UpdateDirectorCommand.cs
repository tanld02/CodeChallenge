using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CodeChallenge.App.Core.Dto;

namespace CodeChallenge.App.Core.Commands.Directors
{
    public class UpdateDirectorCommand: IRequest<Director_DTO>
    {
        public Director_DTO Dto { get; set; }
    }
}
