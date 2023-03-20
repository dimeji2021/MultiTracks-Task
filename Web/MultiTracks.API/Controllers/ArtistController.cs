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

        public ArtistController(IArtistRepository repository)
        {
            _repository = repository;
        }

        [HttpGet ("{name}", Name = "GetArtist")]
        public async Task<IActionResult> Get(string name)
        {
            var artist = await _repository.GetArtistByNameAsync(name);
            if (artist is not null)
            {
                return Ok(artist);

            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Post(ArtistCreateDto request)
        {
            await _repository.InsertArtistAsync(request);
            return CreatedAtRoute("GetArtist", new {name = request.Title},request);
        }
    }
}
