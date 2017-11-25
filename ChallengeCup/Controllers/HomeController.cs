using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChallengeCup.Models;

namespace ChallengeCup.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public string Error()
        {
            return "error";
        }

        public JsonResult Test()
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            return Json(set);
        }
    }
}
