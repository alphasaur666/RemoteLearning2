using LiveShow.Dal.Models;
using LiveShow.Services.Models.Attendance;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services
{
    public interface IAttendanceService
    {
        Task<AttendanceDto> AttendShow(AttendanceDto attendance, int showId);
        Task<AttendanceDto> UnattendShow(AttendanceDto attendance, int showId);

    }
}
