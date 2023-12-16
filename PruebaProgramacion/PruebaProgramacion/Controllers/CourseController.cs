using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolContext schoolContext;

        public CourseController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.Courses.ToList();
            return View(result);
        }
    }
}
