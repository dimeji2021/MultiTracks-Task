using AutoMapper;
using MultiTracks.API.Domain.Core.Services.IService;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Domain.Models.Entities;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Domain.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ArtistGetDto>> SearchForArtistAsync(string name)
        {
            var artists = await _repository.SearchForArtistAsync(name);
            return _mapper.Map<List<ArtistGetDto>>(artists);
        }
        public async Task<ArtistGetDto> CreateArtistAsync(ArtistCreateDto request)
        {
            var artist = _mapper.Map<Artist>(request);
            var artistCreated = await _repository.CreateArtistAsync(artist);
            return _mapper.Map<ArtistGetDto>(artistCreated);
        }
    }
}
