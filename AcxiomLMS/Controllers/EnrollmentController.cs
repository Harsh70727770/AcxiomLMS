using AcxiomLMS.Data;
using AcxiomLMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcxiomLMS.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        // List of enrollments
        public IActionResult Index()
        {
            var enrollments = _context.Enrollments
                .Include(e => e.User)
                .Include(e => e.Course)
                .ToList();

            return View(enrollments);
        }

        // Assign GET
        [HttpGet]
        public IActionResult Assign()
        {
            ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "FullName");
            ViewBag.Courses = new SelectList(_context.Courses.ToList(), "Id", "Title");
            return View();
        }

        // Assign POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Assign(int userId, int courseId)
        {
            if (userId == 0 || courseId == 0)
            {
                ViewBag.Error = "Please select both user and course.";
                ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "FullName");
                ViewBag.Courses = new SelectList(_context.Courses.ToList(), "Id", "Title");
                return View();
            }

            // check duplicate enrollment
            var exists = _context.Enrollments
                .Any(e => e.UserId == userId && e.CourseId == courseId);

            if (exists)
            {
                ViewBag.Error = "This user is already enrolled in this course.";
            }
            else
            {
                var enrollment = new Enrollment
                {
                    UserId = userId,
                    CourseId = courseId
                };
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
                ViewBag.Success = "Enrollment created successfully.";
            }

            ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "FullName");
            ViewBag.Courses = new SelectList(_context.Courses.ToList(), "Id", "Title");

            return View();
        }

        // Optional: Delete enrollment
        public IActionResult Delete(int id)
        {
            var enroll = _context.Enrollments
                .Include(e => e.User)
                .Include(e => e.Course)
                .FirstOrDefault(e => e.Id == id);

            if (enroll == null) return NotFound();

            return View(enroll);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var enroll = _context.Enrollments.Find(id);
            if (enroll == null) return NotFound();

            _context.Enrollments.Remove(enroll);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
