﻿using MvcMusicStore.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStore.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Album Album { get;  set; }

    }
}
