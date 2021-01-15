using System;
using System.Collections.Generic;

#nullable disable

namespace MusicDB
{
    public partial class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
