using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class StudentController : Controller
    {

        private readonly SchoolContext schoolContext;

        public StudentController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.Students.ToList();
            return View(result);
        }

    }
}
