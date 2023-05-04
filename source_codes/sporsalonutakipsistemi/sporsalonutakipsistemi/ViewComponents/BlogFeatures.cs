using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using System.Linq;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class BlogFeatures : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.Id).Take(4).ToList();
            return View(degerler);

        }
    }
}
