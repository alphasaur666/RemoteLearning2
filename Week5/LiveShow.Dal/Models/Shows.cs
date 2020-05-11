using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Shows
    {

        public long Id { get; set; }
        public bool IsCanceled { get; set; }
        [Required]
        public long ArtistId1 { get; set; } // fk
        
        public long ArtistId { get; set; } //fk
        public DateTime DateTime { get; set; }
        [Required]
        public string Venue { get; set; }
        public long GenreId { get; set; } //fk

        public User Artist { get; set; }
        public User Arttist1 { get; set; }
        public Genres Genre { get; set; }

        public ICollection<User> Attendees;

    }
}
