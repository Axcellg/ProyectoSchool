using Microsoft.AspNetCore.Mvc;
using PruebaProgramacion.Context;

namespace PruebaProgramacion.Controllers
{
    public class StudentGradeController1 : Controller
    {
        private readonly SchoolContext schoolContext;

        public StudentGradeController1(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            var result = this.schoolContext.StudentGrades.ToList();
            return View(result);
        }
    }
}
