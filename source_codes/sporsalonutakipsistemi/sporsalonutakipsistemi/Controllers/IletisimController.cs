using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.Controllers
{
    public class IletisimController : Controller
    {
        ContactRepository contactRepository = new ContactRepository();
        SiteAdressInfoRepository siteAdressInfoRepository = new SiteAdressInfoRepository();
        public IActionResult Index()
        {
            ViewData["MapUrl"] = siteAdressInfoRepository.TGet(1).MapUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                ViewData["MapUrl"] = siteAdressInfoRepository.TGet(1).MapUrl;
                return View();
            }
            else
            {
                contactRepository.TAdd(contact);
                TempData["Onay"] = "Mesajınız başarıyla gönderilmiştir.";
                return RedirectToAction("", "Iletisim", ViewData["Onay"]);
            }

        }


    }
}
