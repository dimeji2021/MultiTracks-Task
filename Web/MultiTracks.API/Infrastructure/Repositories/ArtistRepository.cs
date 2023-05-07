using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTracks.API.Domain.Models.Entities;
using MultiTracks.API.Infrastructure.IRepositories;

namespace MultiTracks.API.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private AppDbContext _dbContext;

        public ArtistRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Artist>> SearchForArtistAsync(string name)
        {
            return await _dbContext.Artist.Where(x => x.Title.ToLower().Contains(name.ToLower())).ToListAsync();

        }
        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            await _dbContext.Artist.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
            return artist;
        }
    }
}
