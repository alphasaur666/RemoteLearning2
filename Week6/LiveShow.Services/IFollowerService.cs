using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services
{
    public interface IFollowerService
    {
        Task<FollowerDto> AddFollower(FollowerDto follower);
        Task<FollowerDto> RemoveFollower(int FollowerId);
    }
}
