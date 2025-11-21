using AcxiomLMS.Data;
using AcxiomLMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcxiomLMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Course
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        // GET: Course/Details/5
        public IActionResult Details(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Course/Edit/5
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null) return NotFound();

            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Course/Delete/5
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null) return NotFound();

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null) return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
