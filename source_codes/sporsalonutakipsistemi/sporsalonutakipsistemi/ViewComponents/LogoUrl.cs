using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class LogoUrl : ViewComponent
    {
        SiteInfoRepository infoRepository = new SiteInfoRepository();
        public IViewComponentResult Invoke()
        {
            var deger = infoRepository.TGet(1);
            return View(deger);
        }
    }
}
