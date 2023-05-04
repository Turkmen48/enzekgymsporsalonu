using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using System;
using System.Linq;

namespace sporsalonutakipsistemi.ViewComponents
{
    public class MUsersCount : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            DateTime thisMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime thisMonthEnd = thisMonthStart.AddMonths(1).AddDays(-1);

            var monthlyUser = c.UserInfos.Where(x => x.RegistrationDate >= thisMonthStart && x.RegistrationDate <= thisMonthEnd).Count();

            return View(monthlyUser);
        }
    }
}