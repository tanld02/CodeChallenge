using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using CodeChallenge.App.Api.Controllers;
using CodeChallenge.App.ApiTest.Mock;
using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Infrastructure.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using CodeChallenge.App.Core.Dto;
using MediatR;
using CodeChallenge.App.Core.Queries.Directors;
using System.Threading;

namespace CodeChallenge.App.ApiTest
{
    public class DirectorControllerTest
    {
        private DirectorsController _directorController;
        private Mock<ILogger<DirectorsController>> _logger;
        private IUnitOfWork _unitOfWork;
        private Mock<IMovieRepository> _movieRepository;
        private Mock<IDirectorRepository> _directorRepository;
        private Mock<IDbContext> _dbContext;
        private Mock<IMediator> _mediatorMock;
        public DirectorControllerTest()
        {
            _logger = new Mock<ILogger<DirectorsController>>();
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task GetAllDirectors_ReturnListDirectorsData_WhenServerRespondsSuccessfully()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetDirectorsAllQuery>(), default(CancellationToken)))
                .ReturnsAsync(DirectorMockData.MockListDirectorsData());
            _directorController = new DirectorsController(_logger.Object, _mediatorMock.Object);

            // Act
            var result = await _directorController.GetDirectorsAll().ConfigureAwait(false);

            // Assert
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(result);
            var count = Assert.IsAssignableFrom<List<Director_DTO>>(okObjectResult.Value)?.Count ?? 0;
            Assert.Equal(3, count);
        }
    }
}
