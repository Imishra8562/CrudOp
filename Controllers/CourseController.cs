using CrudOp.Models;
using CrudOp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Diagnostics;

namespace CrudOp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService service, ILogger<CourseController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var courses = _service.GetAllCourses();
            return View(courses);
        }

        public ActionResult Details(int id)
        {
            var course = _service.GetCourseById(id);
            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _service.AddCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Edit(int id)
        {
            var course = _service.GetCourseById(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int id)
        {
            var course = _service.GetCourseById(id);
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.DeleteCourse(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
