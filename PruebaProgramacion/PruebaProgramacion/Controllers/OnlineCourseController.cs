using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class OnlineCourseController : Controller
    {
        private readonly SchoolContext schoolContext;

        public OnlineCourseController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.OnlineCourses.ToList();
            return View(result);
        }
    }
}
