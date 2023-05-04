using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sporsalonutakipsistemi.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        AdminRepository adminRepository = new AdminRepository();
        UserRepository userRepository = new UserRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (adminRepository.TGetAdmin(admin.Username, admin.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var useridentity = new ClaimsIdentity(claims, "MyScheme");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync("MyScheme", principal);
                return RedirectToAction("Index", "Admin");
            }
            ViewData["Hata"] = "Böyle bir kullanıcı yok!";
            return View();
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(User user)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            else if (userRepository.TGetUser(user.Email, user.Password))
            {
                var deger = userRepository.TGet(x => x.Email == user.Email).Id;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Sid, deger.ToString()),
                    new Claim(ClaimTypes.Role, "User")
                };
                var useridentity = new ClaimsIdentity(claims, "MyScheme");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync("MyScheme", principal);
                return RedirectToAction("Index", "User");
            }
            ViewData["Hata"] = "Böyle bir kullanıcı yok veya aktif değil!";
            return View();
        }
    }
}
