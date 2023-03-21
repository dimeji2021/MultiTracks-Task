using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Models.Dtos;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _repository;
        private readonly ILogger<ArtistController> _log;

        public ArtistController(IArtistRepository repository, ILogger<ArtistController> log)
        {
            _repository = repository;
            _log = log;
        }

        [HttpGet("search/{name}", Name = "search")]
        public async Task<IActionResult> Search(string name)
        {
            _log.LogInformation("Executing Get Artist by name endpoint");
            var artist = await _repository.GetArtistByNameAsync(name);
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
        public async Task<IActionResult> Add(ArtistCreateDto request)
        {
            _log.LogInformation("Executing Add Artist to database");
            await _repository.InsertArtistAsync(request);
            return CreatedAtRoute("search", new { name = request.Title }, request);
        }
    }
}
