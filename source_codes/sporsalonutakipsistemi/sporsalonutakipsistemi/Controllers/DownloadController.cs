using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Repositories;
using System;
using System.IO;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DownloadController : Controller
    {
        UserInfoRepository userInfoRepository = new UserInfoRepository();
        RevenueRepository revenueRepository = new RevenueRepository();
        ExpenseRepository expenseRepository = new ExpenseRepository();
        PriceRepository priceRepository = new PriceRepository();
        public IActionResult UserListDownload()
        {
            var degerler = userInfoRepository.TList("User", "Price");
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Kisiler");
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Ad";
            worksheet.Cell(1, 3).Value = "Soyad";
            worksheet.Cell(1, 4).Value = "Telefon";
            worksheet.Cell(1, 5).Value = "Plan";
            worksheet.Cell(1, 6).Value = "Plan Başlama Tarihi";
            worksheet.Cell(1, 7).Value = "Plan Bitiş Tarihi";
            worksheet.Cell(1, 8).Value = "Email";
            worksheet.Cell(1, 9).Value = "Şifre";
            worksheet.Cell(1, 10).Value = "Kayıt Tarihi";
            for (int i = 0; i < degerler.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = degerler[i].Id;
                worksheet.Cell(i + 2, 2).Value = degerler[i].Name;
                worksheet.Cell(i + 2, 3).Value = degerler[i].Surname;
                worksheet.Cell(i + 2, 4).Value = degerler[i].Phone;
                worksheet.Cell(i + 2, 5).Value = degerler[i].Price.Title;
                worksheet.Cell(i + 2, 6).Value = degerler[i].PlanStartDate.Value.ToString("dd/MM/yyyy");
                worksheet.Cell(i + 2, 7).Value = degerler[i].PlanEndDate.Value.ToString("dd/MM/yyyy");
                worksheet.Cell(i + 2, 8).Value = degerler[i].User.Email;
                worksheet.Cell(i + 2, 9).Value = degerler[i].User.Password;
                worksheet.Cell(i + 2, 10).Value = degerler[i].RegistrationDate.Value.ToString("dd/MM/yyyy");
            }

            // Excel dosyası belleğe alınıyor.
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"kisiler{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
        }

        public IActionResult RevenueDownload()
        {
            var deger = revenueRepository.TList();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Gelirler");
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Gelir";
            worksheet.Cell(1, 3).Value = "Ay";
            worksheet.Cell(1, 4).Value = "Yıl";
            worksheet.Cell(1, 5).Value = "Açıklama";

            for (int i = 0; i < deger.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = deger[i].Id;
                worksheet.Cell(i + 2, 2).Value = $"{deger[i].PriceValue} ₺";
                worksheet.Cell(i + 2, 3).Value = deger[i].Month;
                worksheet.Cell(i + 2, 4).Value = deger[i].Year;
                worksheet.Cell(i + 2, 5).Value = deger[i].Description;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"gelirler{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
        }

        public IActionResult ExpenseDownload()
        {
            var deger = expenseRepository.TList();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Giderler");
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Gider";
            worksheet.Cell(1, 3).Value = "Ay";
            worksheet.Cell(1, 4).Value = "Yıl";
            worksheet.Cell(1, 5).Value = "Açıklama";

            for (int i = 0; i < deger.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = deger[i].Id;
                worksheet.Cell(i + 2, 2).Value = $"{deger[i].ExpenseValue} ₺";
                worksheet.Cell(i + 2, 3).Value = deger[i].Month;
                worksheet.Cell(i + 2, 4).Value = deger[i].Year;
                worksheet.Cell(i + 2, 5).Value = deger[i].Description;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"giderler{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
        }

        public IActionResult PricingDownload()
        {
            var deger = priceRepository.TList();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Fiyatlar");
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Başlık";
            worksheet.Cell(1, 3).Value = "Fiyat";
            worksheet.Cell(1, 4).Value = "Ay";
            worksheet.Cell(1, 5).Value = "Açıklama";

            for (int i = 0; i < deger.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = deger[i].Id;
                worksheet.Cell(i + 2, 2).Value = deger[i].Title;
                worksheet.Cell(i + 2, 3).Value = $"{deger[i].PriceValue} ₺";
                worksheet.Cell(i + 2, 4).Value = deger[i].Months;
                worksheet.Cell(i + 2, 5).Value = deger[i].Description;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"fiyatlar{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
        }
    }
}
