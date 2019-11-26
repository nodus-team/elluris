using Microsoft.AspNetCore.Mvc;
using Nodus.NodusArt.Mvc.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Nodus.NodusArt.Mvc.Controllers
{
    
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
