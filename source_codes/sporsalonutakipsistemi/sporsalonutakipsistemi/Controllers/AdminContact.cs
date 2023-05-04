using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContact : Controller
    {
        ContactRepository contactRepository = new ContactRepository();
        public IActionResult Index()
        {
            var degerler = contactRepository.TList();
            return View(degerler);
        }

        public IActionResult Delete(int id)
        {
            var deger = contactRepository.TGet(id);
            contactRepository.TRemove(deger);
            return RedirectToAction("Index", "AdminContact");
        }

        public IActionResult MarkRead(int id)
        {
            var deger = contactRepository.TGet(id);
            deger.IsRead = true;
            contactRepository.TUpdate(deger);
            return RedirectToAction("Index", "AdminContact");
        }
    }
}
