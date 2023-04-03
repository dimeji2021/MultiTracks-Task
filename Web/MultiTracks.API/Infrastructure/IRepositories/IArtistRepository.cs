using MultiTracks.API.Domain.Models.Dtos;

namespace MultiTracks.API.Infrastructure.IRepositories
{
    public interface IArtistRepository
    {
        Task<List<ArtistGetDto>> GetArtistByNameAsync(string name);
        Task<ArtistGetDto> InsertArtistAsync(ArtistCreateDto request);
    }
}