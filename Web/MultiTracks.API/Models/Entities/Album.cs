namespace MultiTracks.API.Models.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public DateTime DateCreation { get; set; }

        //Navigation property
        public int ArtistId { get; set; }
        //public Artist Artist { get; set; }
    }
}
