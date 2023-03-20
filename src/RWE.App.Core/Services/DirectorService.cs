using RWE.App.Core.Dto;
using RWE.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.App.Core.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DirectorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }    
        public async Task<Director_DTO> CreateDirector(Director_DTO director_DTO)
        {
            var result = await _unitOfWork.DirectorRepository.CreateDirector(director_DTO).ConfigureAwait(false);
            if (result == null)
            {
                throw new Exception();
            }
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<Guid> DeleteDirector(Guid directorId)
        {
            var result = await _unitOfWork.DirectorRepository.DeleteDirector(directorId).ConfigureAwait(false);
            if(result == Guid.Empty)
            {
                throw new Exception();
            }    
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<Director_DTO> UpdateDirector(Director_DTO director_DTO)
        {
            var result = await _unitOfWork.DirectorRepository.UpdateDirector(director_DTO).ConfigureAwait(false);

            if (result == null)
            {
                throw new Exception();
            }
            await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
            return director_DTO;
        }
    }
}
