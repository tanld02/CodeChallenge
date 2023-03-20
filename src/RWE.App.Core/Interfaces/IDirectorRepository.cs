using RWE.App.Core.Dto;
using RWE.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.App.Core.Interfaces
{
    public interface IDirectorRepository : IGenericRepository<Director>
    {
        Task<IEnumerable<Director_DTO>> GetDirectorsAll();
        Task<Director_DTO> GetDirectorById(Guid directorId);
        Task<Director_DTO> CreateDirector(Director_DTO dto);
        Task<Director_DTO> UpdateDirector(Director_DTO dto);
        Task<Guid> DeleteDirector(Guid directorId);
    }
}
