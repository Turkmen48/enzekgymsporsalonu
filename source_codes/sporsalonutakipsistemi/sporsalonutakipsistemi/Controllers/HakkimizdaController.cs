using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.Controllers
{

    public class HakkimizdaController : Controller
    {
        SiteInfoRepository infoRepo = new SiteInfoRepository();
        public IActionResult Index()
        {
            var hakkimizda = infoRepo.TList();

            return View(hakkimizda);
        }
    }
}
