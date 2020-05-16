using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Attendance
    {
        public long ShowId { get; set; }
        public long AttendeeID { get; set; }

        public User Attendee { get; set; }
        public Show Show { get; set; }

        

    }
}
