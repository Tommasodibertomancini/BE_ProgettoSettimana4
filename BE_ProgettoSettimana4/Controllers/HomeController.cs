using System.Diagnostics;
using BE_ProgettoSettimana4.Data;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProgettoSettimana4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
