using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System;
using System.Globalization;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RevenueController : Controller
    {
        RevenueRepository revenueRepository = new RevenueRepository();
        public IActionResult Index()
        {
            var degerler = revenueRepository.TList();
            return View(degerler);
        }

        public IActionResult Delete(int id)
        {
            var deger = revenueRepository.TGet(id);
            revenueRepository.TRemove(deger);
            return RedirectToAction("Index", "Revenue");
        }


        public IActionResult Add()
        {


            return View();

        }

        [HttpPost]
        public IActionResult Add(Revenue revenue)
        {

            try
            {

                DateTime myDateTime = DateTime.ParseExact(revenue.Month, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                revenue.Month = myDateTime.Month.ToString();
                revenue.Year = myDateTime.Year.ToString();
                revenueRepository.TAdd(revenue);
                return RedirectToAction("Index", "Revenue");
            }
            catch (Exception ex)
            {
                ViewData["Hata"] = ex.Message;
                return View();
            }
        }
    }
}
