namespace MultiTracks.API.Models.Dtos
{
    public class ArtistGetDto
    {
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public string HeroUrl { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
