using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CodeChallenge.App.Core.Dto;

namespace CodeChallenge.App.Infrastructure.Repository;

public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
{
    private readonly IDbContext _context;
    public DirectorRepository(IDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Director_DTO> CreateDirector(Director_DTO dto)
    {
        var result = _context.Directors.Add(new Director()
        {
            Uuid = Guid.NewGuid(),
            Name = dto.Name,
            Birthdate = dto.Birthdate
        });

        if(result != null)
        {
            dto.Uuid = result.Entity.Uuid;
            return dto;
        }  
        else
        {
            throw new Exception();
        }   
    }

    public async Task<Guid> DeleteDirector(Guid directorId)
    {
        var result = await Task.FromResult(_context.Directors.Remove(new Director() { Uuid = directorId }));
        if (result != null)
        {
            return result.Entity.Uuid;
        }
        else
        {
            throw new NullReferenceException();
        };
    }

    public async Task<Director_DTO> GetDirectorById(Guid directorId)
    {
        return await _context.Directors.
            AsNoTracking()
            .Where(c => c.Uuid == directorId)?
            .Select(c => new Director_DTO()
            {
                Birthdate = c.Birthdate,
                Name = c.Name,
                Uuid = c.Uuid
            })?
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Director_DTO>> GetDirectorsAll()
    {
        var result = await _context.Directors
            .Include(i => i.Movie)
            .AsNoTracking()
            .ToListAsync();

        var directorDTOs = new List<Director_DTO>();

        foreach (var director in result ?? new List<Director>())
        {
            var directorDTO = new Director_DTO()
            {
                Birthdate = director.Birthdate,
                Name = director.Name,
                Uuid = director.Uuid
            };

            directorDTOs.Add(directorDTO);
        }

        return directorDTOs;
    }

    public async Task<Director_DTO> UpdateDirector(Director_DTO director)
    {
        if (director == null)
        {
            return null;
        }

        var result = _context.Directors.Update(new Director()
        {
            Uuid = director.Uuid,
            Name = director.Name,
            Birthdate = director.Birthdate
        });
        if (result != null)
        {
            return director;
        }
        else
        {
            throw new Exception();
        };
    }
}

