using MultiTracks.API.Domain.Models.Dtos;

namespace MultiTracks.API.Infrastructure.IRepositories
{
    public interface ISongRepository
    {
        Task<List<SongDto>> GetAllSongsAsync(RequestParam requestParam);
    }
}