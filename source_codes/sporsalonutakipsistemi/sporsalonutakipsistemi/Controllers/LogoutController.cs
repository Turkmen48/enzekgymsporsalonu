using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace sporsalonutakipsistemi.Controllers
{
    public class LogoutController : Controller
    {
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync("MyScheme");
            return RedirectToAction("Index", "Login");

        }
        public async Task<IActionResult> LogoutUser()
        {
            await HttpContext.SignOutAsync("MyScheme");
            return RedirectToAction("UserLogin", "Login");

        }
    }
}
