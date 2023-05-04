using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.ViewComponents
{
	public class IndexAdress : ViewComponent
	{
		SiteAdressInfoRepository siteAdressInfoRepository = new SiteAdressInfoRepository();
		public IViewComponentResult Invoke()
		{
			var deger = siteAdressInfoRepository.TGet(1);

			return View(deger);
		}
	}
}
