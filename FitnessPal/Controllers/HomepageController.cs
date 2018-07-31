using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPal.Controllers
{
    public class HomepageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
