using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using CodeChallenge.App.Api.Controllers;
using CodeChallenge.App.ApiTest.Mock;
using CodeChallenge.App.Core.Dto;
using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Core.Queries.Movies;
using CodeChallenge.App.Infrastructure.UnitsOfWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenge.App.ApiTest
{
    public class MovieControllerTest
    {
        private MoviesController _moviesController;
        private Mock<ILogger<MoviesController>> _logger;
        private Mock<IMediator> _mediatorMock;
        public MovieControllerTest()
        {
            _logger = new Mock<ILogger<MoviesController>>();
            _mediatorMock = new Mock<IMediator>();
        }


        [Fact]
        public async Task GetAllMovies_ReturnListMoviesData_WhenServerRespondsSuccessfully()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetMoviesAllQuery>(), default(CancellationToken)))
                .ReturnsAsync(MovieMockData.MockListMoviesData());
            _moviesController = new MoviesController(_logger.Object, _mediatorMock.Object);

            // Act
            var result = await _moviesController.GetMoviesAll().ConfigureAwait(false);

            // Assert
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(result);
            var count = Assert.IsAssignableFrom<List<Movie_DTO>>(okObjectResult.Value)?.Count ?? 0;
            Assert.Equal(3, count);
        }
    }
}