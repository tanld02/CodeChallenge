using RWE.App.Core.Interfaces;
using RWE.App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RWE.App.Core.Dto;

namespace RWE.App.Infrastructure.Repository;

public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
{
    private readonly IDbContext _context;
    public DirectorRepository(IDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<Director_DTO> GetDirectorById(Guid directorId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Director_DTO>> GetDirectorByName(string directorName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Director_DTO>> GetDirectorsAll()
    {
        throw new NotImplementedException();
    }
}

