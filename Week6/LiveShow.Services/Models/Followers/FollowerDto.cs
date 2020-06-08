using LiveShow.Dal;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Services.Models.Followers
{
    public class FollowerDto
    {
        public long FollowerId { get; set; }

        public long FolloweeId { get; set; }

        public UserDto Follower { get; set; }

        public UserDto Followee { get; set; }

    }
}
