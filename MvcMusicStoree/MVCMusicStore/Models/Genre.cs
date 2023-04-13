using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Models
{
    public partial class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album>? Albums { get; set; }
    }
}