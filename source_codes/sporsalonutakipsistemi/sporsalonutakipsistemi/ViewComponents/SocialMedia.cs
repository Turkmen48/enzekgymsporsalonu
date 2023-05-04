using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.ViewComponents
{
	public class SocialMedia : ViewComponent
	{
		SiteInfoRepository info = new SiteInfoRepository();
		public IViewComponentResult Invoke()
		{
			var deger = info.TGet(1);
			return View(deger);
		}
	}
}
