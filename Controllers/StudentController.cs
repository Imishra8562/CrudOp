using Microsoft.AspNetCore.Mvc;

namespace CrudOp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
