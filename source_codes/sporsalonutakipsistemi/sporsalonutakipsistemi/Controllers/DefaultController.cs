using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.Controllers
{
    public class DefaultController : Controller
    {
        //index sayfası ana sayfa yani
        PriceRepository price = new PriceRepository();
        SiteAdressInfoRepository siteAdressInfo = new SiteAdressInfoRepository();
        public IActionResult Index()
        {
            var liste = price.TList();
            ViewData["Telefon"] = siteAdressInfo.TGet(1).Phone;
            return View(liste);
        }



    }
}
