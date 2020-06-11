using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LiveShow.Dal.Models
{
    public class Show
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public User Artist { get; set; }

        public int ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Show()
        {
            Attendances = new Collection<Attendance>();
        }
    }
}