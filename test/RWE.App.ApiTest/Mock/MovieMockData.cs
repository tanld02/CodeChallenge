using RWE.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWE.App.ApiTest.Mock
{
    public static class MovieMockData
    {
        public static IEnumerable<Movie_DTO> MockListMoviesData()
        {
            return new List<Movie_DTO>()
            {
                new Movie_DTO()
                {
                    DirectorId = Guid.Parse("7A2799EA-2176-4B81-A1E4-0026926E6257"),
                    Uuid = Guid.Parse("4EFB5AC6-9E64-40CF-86D7-07B568E8289A"),
                    Rating = 8,
                    ReleaseDate = DateTime.Now,
                    Title = "Task 1"
                },
                new Movie_DTO()
                {
                    DirectorId = Guid.Parse("7A2799EA-2176-4B81-A1E4-0026926E6257"),
                    Uuid = Guid.Parse("4EFB5AC6-9E64-40CF-86D7-07B568E8289A"),
                    Rating = 8,
                    ReleaseDate = DateTime.Now,
                    Title = "Task 2"
                },            
                new Movie_DTO()
                {
                    DirectorId = Guid.Parse("7A2799EA-2176-4B81-A1E4-0026926E6257"),
                    Uuid = Guid.Parse("93C121D7-8FAF-429B-88EC-44A8D2880C49"),
                    Rating = 8,
                    ReleaseDate = DateTime.Now,
                    Title = "Task 3"
                }
            };
        }
    }
}
