using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Domain.Models.Entities;

namespace MultiTracks.API.Infrastructure.IRepositories
{
    public interface ISongRepository
    {
        Task<List<Song>> GetAllSongsAsync(RequestParam requestParam);
    }
}