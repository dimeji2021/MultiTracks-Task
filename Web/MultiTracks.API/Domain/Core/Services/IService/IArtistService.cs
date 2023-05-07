using MultiTracks.API.Domain.Models.Dtos;

namespace MultiTracks.API.Domain.Core.Services.IService
{
    public interface IArtistService
    {
        Task<List<ArtistGetDto>> SearchForArtistAsync(string name);
        Task<ArtistGetDto> CreateArtistAsync(ArtistCreateDto request);
    }
}