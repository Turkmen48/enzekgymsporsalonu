using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using System.Linq;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class BlogFirstFeature : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.Id).Take(5).ToList();
            return View(degerler[4]);

        }
    }
}
