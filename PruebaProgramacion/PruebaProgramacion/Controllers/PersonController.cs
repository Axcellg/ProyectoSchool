using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class PersonController : Controller
    {
        private readonly SchoolContext schoolContext;

        public PersonController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.Person.ToList();
            return View(result);
        }
    }
}
