using MultiTracks.API.Domain.Models.Dtos;

namespace MultiTracks.API.Domain.Core.Services.IService
{
    public interface ISongService
    {
        Task<List<SongDto>> GetAllSongsAsync(RequestParam requestParam);
    }
}