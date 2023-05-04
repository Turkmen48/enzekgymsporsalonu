using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using System.Linq;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class Notifications : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var deger = context.Contacts.Where(x => x.IsRead == false).Count();

            return View(deger);
        }
    }
}
