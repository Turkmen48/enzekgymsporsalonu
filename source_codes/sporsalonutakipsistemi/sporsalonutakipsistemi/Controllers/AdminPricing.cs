using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPricing : Controller
    {
        PriceRepository priceRepository = new PriceRepository();
        public IActionResult Index()
        {
            var degerler = priceRepository.TList();
            return View(degerler);
        }

        public IActionResult AddPrice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPrice(Price price)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            price.Status = true;
            priceRepository.TAdd(price);
            return RedirectToAction("Index", "AdminPricing");
        }

        public IActionResult Delete(int id)
        {
            var price = priceRepository.TGet(id);
            price.Status = false;
            priceRepository.TUpdate(price);
            return RedirectToAction("Index", "AdminPricing");
        }

        public IActionResult Edit(int id)
        {
            var deger = priceRepository.TGet(id);
            return View(deger);
        }

        [HttpPost]
        public IActionResult Edit(Price price)
        {
            price.Status = true;
            priceRepository.TUpdate(price);
            return RedirectToAction("Index", "AdminPricing");
        }
    }



}

