using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class DeparmentController : Controller
    {
        private readonly SchoolContext schoolContext;

        public DeparmentController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.Departments.ToList();
            return View(result);
        }
    }
}
