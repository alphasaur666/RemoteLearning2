using System;
using System.Collections.Generic;
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
        public IActionResult GetNotification(NotificationDto notificationDto, int notificationId)
        {
            var Notification = notificationService.GetNotification(notificationId);
            return Ok(Notification);
        }
        


    }
}
