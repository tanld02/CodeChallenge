using Microsoft.AspNetCore.Mvc;
using RWE.App.Core.Dto;
using RWE.App.Core.Interfaces;

namespace RWE.App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorsController :  ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DirectorsController(
            ILogger<MoviesController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetDirectorsAll()
        {
            try
            {
                var result = await _unitOfWork.DirectorRepository.GetDirectorsAll().ConfigureAwait(false);
                if(result == null)
                {
                    return NoContent();
                }    
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{directorId}")]
        public async Task<IActionResult> GetDirectorById(Guid directorId)
        {
            try
            {
                if (directorId == Guid.Empty)
                {
                    return BadRequest();
                }
                var result = await _unitOfWork.DirectorRepository.GetDirectorById(directorId).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector(Director_DTO director)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _unitOfWork.DirectorRepository.CreateDirector(director).ConfigureAwait(false);
                if (result == null)
                {
                    return StatusCode(500);
                }
                await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDirector(Director_DTO director)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _unitOfWork.DirectorRepository.UpdateDirector(director).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound();
                }
                await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDirector(Guid directorId)
        {
            try
            {
                var result = await _unitOfWork.DirectorRepository.DeleteDirector(directorId).ConfigureAwait(false);
                await _unitOfWork.SaveChangeAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message} \n StackTrace: {ex.StackTrace}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
