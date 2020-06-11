using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using LiveShow.Services;
using LiveShow.Services.Models.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api.Controllers
{
    [ApiController]
    public class NotificationController : LiveShowApiControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        
        [HttpGet("{notificationId}")]
        public async Task<IActionResult> GetNotification(int notificationId)
        {
            var Notification = await notificationService.GetNotification(notificationId);
            return Ok(Notification);
        }

        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            var notifications = notificationService.GetAllNotifications();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationDto notificationDto)
        {
            var creteadNotification = await notificationService.CreateNotification(notificationDto);
            return Ok(creteadNotification);
        }

        


    }
}
