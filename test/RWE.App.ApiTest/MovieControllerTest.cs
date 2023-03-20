using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RWE.App.Api.Controllers;
using RWE.App.ApiTest.Mock;
using RWE.App.Core.Dto;
using RWE.App.Core.Interfaces;
using RWE.App.Infrastructure.UnitsOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RWE.App.ApiTest
{
    public class MovieControllerTest
    {
        private MoviesController _moviesController;
        private Mock<ILogger<MoviesController>> _logger;
        private IUnitOfWork _unitOfWork;
        private Mock<IMovieRepository> _movieRepository;
        private Mock<IDirectorRepository> _directorRepository;
        private Mock<IDbContext> _dbContext;
        public MovieControllerTest()
        {
            _logger = new Mock<ILogger<MoviesController>>();
        }


        [Fact]
        public async Task GetAllMovies_ReturnListMoviesData_WhenServerRespondsSuccessfully()
        {
            // Arrange
            _movieRepository = new Mock<IMovieRepository>();
            _directorRepository = new Mock<IDirectorRepository>();
            _dbContext = new Mock<IDbContext>();
            _unitOfWork = new UnitOfWork(_movieRepository.Object, _directorRepository.Object, _dbContext.Object);

            _movieRepository.Setup(x => x.GetMoviesAll())
                .ReturnsAsync(MovieMockData.MockListMoviesData());
            _dbContext.Setup(db => db.SaveAsync()).Verifiable();
            _moviesController = new MoviesController(_logger.Object, _unitOfWork);

            // Act
            var result = await _moviesController.GetMoviesAll().ConfigureAwait(false);

            // Assert
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(result);
            var count = Assert.IsAssignableFrom<List<Movie_DTO>>(okObjectResult.Value)?.Count ?? 0;
            Assert.Equal(3, count);
        }
    }
}