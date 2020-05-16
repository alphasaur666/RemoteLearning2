namespace LiveShow.Dal.Models
{
    public class Attendance
    {
        public Show Show { get; set; }

        public User Attendee { get; set; }

        public int ShowId { get; set; }

        public long AttendeeId { get; set; }
    }
}
