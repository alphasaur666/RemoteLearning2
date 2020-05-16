using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Genre
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string GenreName { get; set;}

    }
}
