using AutoMapper;
using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Attendance;
using LiveShow.Services.Models.Show;
using LiveShow.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AttendanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        public async Task<AttendanceDto> AttendShow(AttendanceDto attendance, int showId)
        {
            var updatedAttendanceDto = new AttendanceDto
            {
                AttendeeId = attendance.AttendeeId,
                ShowId = showId
            };

            var updatedAttendance = mapper.Map<Attendance>(updatedAttendanceDto);
            await unitOfWork.AttendanceRepository.UpdateAsync(updatedAttendance);

            var returnedUpdatedShow = mapper.Map<AttendanceDto>(updatedAttendance);        
            return returnedUpdatedShow;
            
        }

        public async Task<AttendanceDto> UnattendShow(AttendanceDto attendance, int showId)
        {
            var updatedAttendanceDto = new AttendanceDto
            {
                AttendeeId = attendance.AttendeeId,
                ShowId = showId
            };

            var updatedAttendance = mapper.Map<Attendance>(updatedAttendanceDto);
            await unitOfWork.AttendanceRepository.DeleteAsync(updatedAttendance);

            var returnedRemovedShow = mapper.Map<AttendanceDto>(updatedAttendance);
            return returnedRemovedShow;                      
        }
    }
}
