using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTracks.API.Models.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string TimeSignature { get; set; }
        public decimal Bpm { get; set; }
        public bool Multitracks { get; set; }
        public bool CustomMix { get; set; }
        public bool Chart { get; set; }
        public bool RehearsalMix { get; set; }
        public bool Patches { get; set; }
        public bool SongSpecificPatches { get; set; }
        public bool ProPresenter { get; set; }
        public DateTime DateCreation { get; set; }

        //Navigation property
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }


    }
}
