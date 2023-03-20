using MultiTracks.API.Models.Dtos;

namespace MultiTracks.API.Infrastructure.IRepositories
{
    public interface IArtistRepository
    {
        Task<ArtistGetDto> GetArtistByNameAsync(string name);
        Task InsertArtistAsync(ArtistCreateDto request);
    }
}