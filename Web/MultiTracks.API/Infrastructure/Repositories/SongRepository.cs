using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Domain.Models.Entities;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {
        private AppDbContext _dbContext;

        public SongRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Song>> GetAllSongsAsync(RequestParam requestParam)
        {
            int skip = (requestParam.PageNumber - 1) * requestParam.PageSize;
            var songs = await _dbContext.Song
                .Include(x => x.Artist)
                .Include(x => x.Album)
                .OrderBy(x => x.SongId)
                           .Skip(skip)
                           .Take(requestParam.PageSize)
                .ToListAsync();
            return songs;
        }
    }
}
