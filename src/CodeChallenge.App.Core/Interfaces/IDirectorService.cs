using CodeChallenge.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Interfaces
{
    public interface IDirectorService
    {
        Task<Director_DTO> CreateDirector(Director_DTO director_DTO);
        Task<Director_DTO> UpdateDirector(Director_DTO director_DTO);
        Task<Guid> DeleteDirector(Guid directorId);
    }
}
