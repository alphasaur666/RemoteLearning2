using AutoMapper;
using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Followers;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services.Services
{
    public class FollowerService : IFollowerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FollowerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<FollowerDto> AddFollower(FollowerDto follower) //for follow
        {
            var followerDto = mapper.Map<Following>(follower);
            await unitOfWork.FollowingRepository.AddAsync(followerDto);

            var returnedFollower = mapper.Map<FollowerDto>(followerDto);
            return returnedFollower;
        }

        public async Task<FollowerDto> GetFollower(int FollowerId)
        {
            var follower = await unitOfWork.FollowingRepository.GetAsync(f => f.FollowerId == FollowerId);
            var followerDto = mapper.Map<FollowerDto>(follower);
            return followerDto;
        }

        public IEnumerable<FollowerDto> GetAllFollowers(int FolloweeId)
        {
            var followers = unitOfWork.FollowingRepository.GetAll(u => u.FolloweeId == FolloweeId).GetAsyncEnumerator();
            var followersDto = mapper.Map<IEnumerable<FollowerDto>>(followers);
            return followersDto;
        }

        public async Task<FollowerDto> RemoveFollower(int FollowerId) //for unfollow
        {
            var removedFollower = unitOfWork.FollowingRepository.GetAsync(u => u.FollowerId == FollowerId);
            var removedFollowerDto = mapper.Map<Following>(removedFollower);
            await unitOfWork.FollowingRepository.DeleteAsync(removedFollowerDto);

            var returnedRemovedFollower = mapper.Map<FollowerDto>(removedFollowerDto);
            return returnedRemovedFollower;
        }  
    }
}
