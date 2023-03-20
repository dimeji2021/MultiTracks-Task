using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTracks.API.Infrastructure.IRepositories;
using MultiTracks.API.Models.Dtos;

namespace MultiTracks.API.Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public SongRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<SongDto>> GetAllSongsAsync(int pageSize, int pageNumber)
        {
            int skip = (pageNumber - 1) * pageSize;
            var songs = await _dbContext.Song
                .Include(x => x.Artist)
                .Include(x => x.Album)
                .OrderBy(x => x.SongId)
                           .Skip(skip)
                           .Take(pageSize)
                .ToListAsync();
            return _mapper.Map<List<SongDto>>(songs) ;

        }
    }
}
