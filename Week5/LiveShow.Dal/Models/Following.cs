namespace LiveShow.Dal.Models
{
    // Alternatively, this class could be called Relationship.
    public class Following
    {
        public long FollowerId { get; set; }

        public long FolloweeId { get; set; }

        public User Follower { get; set; }

        public User Followee { get; set; }
    }
}