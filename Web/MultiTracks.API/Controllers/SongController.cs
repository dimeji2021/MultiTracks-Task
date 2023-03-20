using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _repository;

        public SongController(ISongRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int pageSize, int pageNumber)
        {
            var songs = await _repository.GetAllSongsAsync(pageSize, pageNumber);
            if (songs is not null)
            {
                return Ok(songs);
            }
            return BadRequest();
        }
    }
}
