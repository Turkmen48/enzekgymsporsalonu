using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System.Linq;
using System.Security.Claims;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        Context context = new Context();
        UserInfoRepository infoRepository = new UserInfoRepository();
        ContactRepository contactRepository = new ContactRepository();
        public IActionResult Index()
        {
            var currentUser = HttpContext.User;
            var usernameClaim = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            if (usernameClaim != null)
            {
                var username = usernameClaim.Value;
                var user = context.UserInfos.Where(x => x.UserId == int.Parse(username)).FirstOrDefault();
                ViewData["PlanEndDate"] = user.PlanEndDate.ToString();
                ViewData["Name"] = user.Name;


            }

            return View();
        }

        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                contactRepository.TAdd(contact);
                TempData["Onay"] = "Mesajınız Başarıyla Gönderildi!";
                return RedirectToAction("SendMessage", "User");
            }
        }

        public IActionResult PriceDetails()
        {
            var currentUser = HttpContext.User;
            var usernameClaim = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            if (usernameClaim != null)
            {
                var username = usernameClaim.Value;
                var user = context.UserInfos.Where(x => x.UserId == int.Parse(username)).Include("Price").FirstOrDefault();

                return View(user);

            }
            return View();
        }
    }
}
