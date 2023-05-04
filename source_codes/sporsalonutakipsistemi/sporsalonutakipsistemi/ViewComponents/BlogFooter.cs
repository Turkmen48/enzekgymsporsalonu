using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using System.Linq;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class BlogFooter : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.Id).Take(2).ToList();
            return View(degerler);
        }
    }
}
