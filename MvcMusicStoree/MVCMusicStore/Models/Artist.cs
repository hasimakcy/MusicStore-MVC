using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}