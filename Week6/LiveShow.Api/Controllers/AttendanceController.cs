using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveShow.Dal.Models;
using LiveShow.Services;
using LiveShow.Services.Models.Attendance;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api.Controllers
{
    public class AttendanceController : LiveShowApiControllerBase
    {
        
        private readonly IAttendanceService attendanceService;


        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<IActionResult> AttendShow(AttendanceDto attendance, int showiD)
        {
            var updatedAttendance = await attendanceService.AttendShow(attendance, showiD);
            return Ok(updatedAttendance);
        }

        [HttpPatch]
        public async Task<IActionResult> UnattendShow(AttendanceDto attendance, int showiD)
        {
           var updatedAttendance = await attendanceService.UnattendShow(attendance, showiD);
           return Ok(updatedAttendance);
                   
        }    
    }
}