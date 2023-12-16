using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private readonly SchoolContext schoolContext;

        public OfficeAssignmentController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.OfficeAssignments.ToList();
            return View(result);
        }
    }
}
