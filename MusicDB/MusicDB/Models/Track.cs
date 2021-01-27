﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable

namespace MusicDB
{
    [DebuggerDisplay("{Name}")]
    public partial class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public double UnitPrice { get; set; }

        public virtual Album Album { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }

        public object This
        {
            get { return this; }
        }
    }
}
