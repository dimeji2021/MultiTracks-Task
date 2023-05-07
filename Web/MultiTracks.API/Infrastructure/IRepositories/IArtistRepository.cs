using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Domain.Models.Entities;

namespace MultiTracks.API.Infrastructure.IRepositories
{
    public interface IArtistRepository
    {
        Task<List<Artist>> SearchForArtistAsync(string name);
        Task<Artist> CreateArtistAsync(Artist artist);
    }
}