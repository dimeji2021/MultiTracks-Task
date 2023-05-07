using AutoMapper;
using MultiTracks.API.Domain.Core.Services.IService;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Domain.Core.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _repository;
        private readonly IMapper _mapper;

        public SongService(ISongRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SongDto>> GetAllSongsAsync(RequestParam requestParam)
        {
            var songs =  await _repository.GetAllSongsAsync(requestParam);
            return _mapper.Map<List<SongDto>>(songs);
        }
    }
}
