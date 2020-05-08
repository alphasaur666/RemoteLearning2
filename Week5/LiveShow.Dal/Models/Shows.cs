using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Shows
    {

        public long Id { get; set; }
        public bool IsCanceled { get; set; }
        public long ArtistId1 { get; set; } // fk
        public long ArtistId { get; set; } //fk
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public long GenreId { get; set; } //fk

    }
}
