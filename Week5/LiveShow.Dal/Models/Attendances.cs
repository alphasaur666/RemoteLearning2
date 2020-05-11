using System;
using System.Collections.Generic;
using System.Text;

namespace LiveShow.Dal.Models
{
    public class Attendances
    {
        public long ShowId { get; set; }
        public long AtendeeID { get; set; }
        public User Atendee { get; set; }
        public User Atender { get; set; }
        public Shows Show { get; set; }

        

    }
}
