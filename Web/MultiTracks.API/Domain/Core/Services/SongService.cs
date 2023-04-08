using MultiTracks.API.Domain.Core.Services.IService;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Domain.Core.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _repository;

        public SongService(ISongRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<SongDto>> GetAllSongsAsync(RequestParam requestParam)
        {
            return await _repository.GetAllSongsAsync(requestParam);
        }
    }
}
