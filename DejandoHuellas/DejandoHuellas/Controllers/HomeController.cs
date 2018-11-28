using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DejandoHuellas.Models;
using Microsoft.AspNetCore.Authorization;

namespace DejandoHuellas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles="Administrator")]
        public IActionResult About()
        {
            ViewData["Message"] = "Dejando Huellas.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Detalles de Contacto.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
