using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System;
using System.Globalization;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExpenseController : Controller
    {
        ExpenseRepository expenseRepository = new ExpenseRepository();
        public IActionResult Index()
        {
            var degerler = expenseRepository.TList();
            return View(degerler);
        }

        public IActionResult Delete(int id)
        {
            var deger = expenseRepository.TGet(id);
            expenseRepository.TRemove(deger);
            return RedirectToAction("Index", "Expense");
        }


        public IActionResult Add()
        {


            return View();

        }

        [HttpPost]
        public IActionResult Add(Expense expense)
        {

            try
            {

                DateTime myDateTime = DateTime.ParseExact(expense.Month, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                expense.Month = myDateTime.Month.ToString();
                expense.Year = myDateTime.Year.ToString();
                expenseRepository.TAdd(expense);
                return RedirectToAction("Index", "Expense");
            }
            catch (Exception ex)
            {
                ViewData["Hata"] = ex.Message;
                return View();
            }
        }
    }
}
