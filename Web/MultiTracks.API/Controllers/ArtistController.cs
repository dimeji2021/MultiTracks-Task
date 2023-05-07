using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Infrastructure.IRepositories;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Domain.Core.Services.IService;

namespace MultiTracks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly ILogger<ArtistController> _log;

        public ArtistController(IArtistService artistService, ILogger<ArtistController> log)
        {
            _artistService = artistService;
            _log = log;
        }

        [HttpGet("search/{name}", Name = "search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Search(string name)
        {
            _log.LogInformation("Executing Get Artist by name endpoint");
            var artist = await _artistService.SearchForArtistAsync(name);
            if (artist is not null)
            {
                _log.LogInformation("Get Artist by name endpoint executed succesfully");

                return Ok(artist);

            }
            _log.LogError("Bad request, error occure while trying to get artist by name.");
            return NotFound();
        }
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ArtistCreateDto request)
        {
            _log.LogInformation("Executing Add Artist to database");
            var artist = await _artistService.CreateArtistAsync(request);
            return CreatedAtRoute("search", new { name = artist.Title }, artist);
        }
    }
}
