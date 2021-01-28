using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable

namespace MusicDB
{
    [DebuggerDisplay("{Name}")]
    public partial class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
