using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get;}
        IDirectorRepository DirectorRepository { get;}
        Task SaveChangeAsync();
    }
}
