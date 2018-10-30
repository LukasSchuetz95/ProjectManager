using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Web.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult EditFeed()
        {
            return View();
        }
    }
}