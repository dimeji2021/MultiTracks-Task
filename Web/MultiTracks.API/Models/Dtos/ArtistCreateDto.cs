using System.ComponentModel.DataAnnotations;

namespace MultiTracks.API.Models.Dtos
{
    public class ArtistCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]

        public string Biography { get; set; }
        [Required]

        public string ImageUrl { get; set; }
        [Required]

        public string HeroUrl { get; set; }
    }
}
