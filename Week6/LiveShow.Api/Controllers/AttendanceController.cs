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
        public async Task<IActionResult> AttendShow(int showId)
        {
            var updatedAttendance = await attendanceService.AttendShow(showId);
            return Ok(updatedAttendance);
        }

        [HttpPatch("{showId}")]
        public async Task<IActionResult> UnattendShow(int showId)
        {
           var updatedAttendance = await attendanceService.UnattendShow(showId);
           return Ok(updatedAttendance);                   
        }
        
    }
}