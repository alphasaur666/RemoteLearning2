using AutoMapper;
using LiveShow.Dal;
using LiveShow.Dal.Models;
using LiveShow.Services.Models.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<NotificationDto> GetNotification(int NotificationId)
        {
            var notification = await unitOfWork.NotificationRepository.GetAsync(n => n.Id == NotificationId);
            var notificationDto = mapper.Map<NotificationDto>(notification);
            return notificationDto;
        }

        public IEnumerable<NotificationDto> GetAllNotifications()
        {
            var notifications = unitOfWork.NotificationRepository.GetAll();
            var notificationsDto = mapper.Map<IEnumerable<NotificationDto>>(notifications);
            return notificationsDto;
        }   
    }
}
