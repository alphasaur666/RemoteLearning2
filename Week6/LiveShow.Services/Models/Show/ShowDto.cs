using LiveShow.Services.Models.User;
using System;

namespace LiveShow.Services.Models.Show
{
    public class ShowDto
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public UserDto Artist { get; set; }

        public int ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDto Genre { get; set; }

        public int GenreId { get; set; }
    }
}
