using CodeChallenge.App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.App.ApiTest.Mock
{
    public static class DirectorMockData
    {
        public static IEnumerable<Director_DTO> MockListDirectorsData()
        {
            return new List<Director_DTO>()
            {
                new Director_DTO()
                {
                    Birthdate = DateTime.Now,
                    Name = "Tan",
                    Uuid = Guid.Parse("7A2799EA-2176-4B81-A1E4-0026926E6257")
                },
                new Director_DTO()
                {
                    Birthdate = DateTime.Now,
                    Name = "Phuc",
                    Uuid = Guid.Parse("93C121D7-8FAF-429B-88EC-44A8D2880C49")
                },            new Director_DTO()
                {
                    Birthdate = DateTime.Now,
                    Name = "Tan",
                    Uuid = Guid.Parse("1398C6AB-5BED-477B-8B34-532FF9093BA3")
                }
            };
        }
    }
}
