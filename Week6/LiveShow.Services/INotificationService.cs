using LiveShow.Services.Models.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Services
{
    public interface INotificationService
    {
        Task<NotificationDto> GetNotification(int NotificationId);
        IEnumerable<NotificationDto> GetAllNotifications();
        Task<NotificationDto> CreateNotification(NotificationDto notification);

    }
}
