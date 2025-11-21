using AcxiomLMS.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcxiomLMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}
