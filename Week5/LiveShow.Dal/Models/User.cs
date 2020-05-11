using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveShow.Dal.Models
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public UserType Type { get; set; }

        public ICollection<Followings> Followers { get; set; }

        public ICollection<Followings> Followees { get; set; }

        public ICollection<Notifications> Notifications { get; set; }

        public ICollection<Attendances> Attendances { get; set; }

        
        public User()
        {
            Followers = new List<Followings>();
            Followees = new List<Followings>();
            Notifications = new List<Notifications>();
            Attendances = new List<Attendances>();
        }
    }
}
