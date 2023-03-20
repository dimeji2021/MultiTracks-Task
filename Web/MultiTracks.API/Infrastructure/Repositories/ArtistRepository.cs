using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTracks.API.Infrastructure.IRepositories;
using MultiTracks.API.Models.Dtos;
using MultiTracks.API.Models.Entities;

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

        public async Task<ArtistGetDto> GetArtistByNameAsync(string name)
        {
            var artist= await _dbContext.Artist.FirstOrDefaultAsync(x => x.Title == name);
            return _mapper.Map<ArtistGetDto>(artist);
        }
        public async Task InsertArtistAsync(ArtistCreateDto request)
        {
            var artist = _mapper.Map<Artist>(request);
            await _dbContext.Artist.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
        }
    }
}
