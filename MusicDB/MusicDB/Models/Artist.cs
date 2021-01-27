﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable

namespace MusicDB
{
    [DebuggerDisplay("{Name}")]
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
