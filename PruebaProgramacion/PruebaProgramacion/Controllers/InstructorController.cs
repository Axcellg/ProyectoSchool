using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class InstructorController : Controller
    {
        private readonly SchoolContext schoolContext;

        public InstructorController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.Instructors.ToList();
            return View(result);
        }
    }
}
