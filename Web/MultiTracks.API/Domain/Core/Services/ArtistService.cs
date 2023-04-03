using MultiTracks.API.Domain.Core.Services.IService;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Domain.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;

        public ArtistService(IArtistRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ArtistGetDto>> GetArtistByNameAsync(string name)
        {
            return await _repository.GetArtistByNameAsync(name);
        }
        public async Task<ArtistGetDto> InsertArtistAsync(ArtistCreateDto request)
        {
            return await _repository.InsertArtistAsync(request);
        }
    }
}
