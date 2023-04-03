using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Domain.Models.Entities;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public ArtistRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ArtistGetDto>> GetArtistByNameAsync(string name)
        {
            var artist = await _dbContext.Artist.Where(x => x.Title.ToLower().Contains(name.ToLower())).ToListAsync();
            return _mapper.Map<List<ArtistGetDto>>(artist);
            
        }
        public async Task<ArtistGetDto> InsertArtistAsync(ArtistCreateDto request)
        {
            var artist = _mapper.Map<Artist>(request);
            await _dbContext.Artist.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ArtistGetDto>(artist);
        }
    }
}
