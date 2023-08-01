using Microsoft.AspNetCore.Mvc;

namespace sporsalonutakipsistemi.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int code)
        {

            return View(ViewData["code"] = code);
        }
    }
}
