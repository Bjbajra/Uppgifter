using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable

namespace PlaylistDB
{
    [DebuggerDisplay("{Name}")]
    public partial class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
