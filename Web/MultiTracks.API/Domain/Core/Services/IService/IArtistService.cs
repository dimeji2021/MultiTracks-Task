using MultiTracks.API.Domain.Models.Dtos;

namespace MultiTracks.API.Domain.Core.Services.IService
{
    public interface IArtistService
    {
        Task<List<ArtistGetDto>> GetArtistByNameAsync(string name);
        Task<ArtistGetDto> InsertArtistAsync(ArtistCreateDto request);
    }
}