using RWE.App.Core.Interfaces;
using RWE.App.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.App.Infrastructure.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IMovieRepository _movieRepository;
        private IDirectorRepository _directorRepository;
        private readonly IDbContext _dbContext;
        public UnitOfWork(IMovieRepository movieRepository, 
            IDirectorRepository directorRepository,
            IDbContext dbContext)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _dbContext = dbContext;
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                return _movieRepository;
            }
        }

        public IDirectorRepository DirectorRepository
        {
            get
            {
                return _directorRepository;
            }
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveAsync();
        }
    }
}
