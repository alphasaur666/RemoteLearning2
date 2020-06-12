using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Website.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
