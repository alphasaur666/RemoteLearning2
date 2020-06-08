using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Services.Models.Attendance
{
    public class AttendanceDto
    {
        public ShowDto Show { get; set; }

        public UserDto Attendee { get; set; }

        public int ShowId { get; set; }

        public long AttendeeId { get; set; }
    }
}
