using Microsoft.AspNetCore.Mvc;

namespace AcxiomLMS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            return View();
        }
        public IActionResult Landing()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        }

    }
}
