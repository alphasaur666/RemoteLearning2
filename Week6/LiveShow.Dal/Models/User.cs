using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveShow.Dal.Models
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Username { get; set; }

        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public UserType Type { get; set; }

        public ICollection<Following> Followers { get; set; }

        public ICollection<Following> Followees { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }

        public User()
        {
            Followers = new List<Following>();
            Followees = new List<Following>();
            UserNotifications = new List<UserNotification>();
        }
    }
}
