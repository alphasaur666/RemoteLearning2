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
        
        public async Task<AttendanceDto> AttendShow(int showId)
        {
            var attendance =  await unitOfWork.AttendanceRepository.GetAsync(a => a.ShowId == showId);
            await unitOfWork.AttendanceRepository.UpdateAsync(attendance);

            var returnedUpdatedShow = mapper.Map<AttendanceDto>(attendance);        
            return returnedUpdatedShow;
            
        }

        public async Task<AttendanceDto> UnattendShow(int showId)
        {
            var attendance = unitOfWork.AttendanceRepository.GetAsync(a => a.ShowId == showId);
            var updatedAttendance = mapper.Map<Attendance>(attendance);
            await unitOfWork.AttendanceRepository.DeleteAsync(updatedAttendance);
            
            var returnedRemovedShow = mapper.Map<AttendanceDto>(updatedAttendance);
            return returnedRemovedShow;                      
        }
    }
}
