using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using System;
using System.Linq;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class MonthlyCharge : ViewComponent
    {

        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            string thisMonth = DateTime.Now.Month.ToString();
            string thisYear = DateTime.Now.Year.ToString();



            var monthlyCharge = c.Revenues.Where(x => x.Month == thisMonth && x.Year == thisYear).Sum(x => x.PriceValue);

            return View(monthlyCharge);
        }
    }
}
