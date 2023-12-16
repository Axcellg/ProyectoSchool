using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class OnsiteCourseController : Controller
    {
        private readonly SchoolContext schoolContext;

        public OnsiteCourseController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.OnsiteCourses.ToList();
            return View(result);
        }
    }
}
