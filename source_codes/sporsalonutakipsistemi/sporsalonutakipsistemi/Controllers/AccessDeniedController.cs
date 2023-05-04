using Microsoft.AspNetCore.Mvc;

namespace sporsalonutakipsistemi.Controllers
{
    public class AccessDeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
