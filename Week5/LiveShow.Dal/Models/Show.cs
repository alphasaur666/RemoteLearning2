using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Show
    {

        public long Id { get; set; }
        public bool IsCanceled { get; set; }
        [Required] 
        public long ArtistId { get; set; } //fk
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Venue { get; set; }
        public long GenreId { get; set; } //fk

        public User Artist { get; set; }
        public Genre Genre { get; set; }

        public ICollection<User> Attendees;

        public Show()
        {
            Attendees = new List<User>();
        }

    }
}
