using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        UserInfoRepository userInfoRepository = new UserInfoRepository();
        UserRepository userRepository = new UserRepository();
        PriceRepository priceRepository = new PriceRepository();
        SiteInfoRepository siteInfoRepository = new SiteInfoRepository();
        SiteAdressInfoRepository siteAdressInfoRepository = new SiteAdressInfoRepository();
        RevenueRepository revenueRepository = new RevenueRepository();
        public List<SelectListItem> dropDown()
        {
            List<SelectListItem> degerler = (from x in priceRepository.TList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            return degerler;
        }


        public IActionResult Index()
        {
            //User user = new User();
            //user.Email = "anweeen@gmail.com";
            //user.Password = "password";
            //userRepository.TAdd(user);

            //UserInfo userInfo = new UserInfo();
            //userInfo.Name = "Ahmet";
            //userInfo.Surname = "durmus";
            //userInfo.Tc = 20396082711;
            //userInfo.RegistrationDate = DateTime.Now;
            //userInfo.Birthday = DateTime.Now;
            //userInfo.PlanStartDate = DateTime.Now;
            //userInfo.PlanEndDate = DateTime.Now;
            //userInfo.PriceId = 1;
            //userInfo.UserId = user.Id;
            //userInfo.Phone = "5061793786";
            //userInfoRepository.TAdd(userInfo);
            //var degerler = userInfoRepository.TList("User", "Price");

            return View();
        }

        public IActionResult EditSiteName()
        {
            var deger = siteInfoRepository.GetFirst();
            return View(deger);
        }

        [HttpPost]
        public IActionResult EditSiteName(SiteInfo siteInfo)
        {
            var deger = siteInfoRepository.GetFirst();
            deger.SiteName = siteInfo.SiteName;
            siteInfoRepository.TUpdate(deger);
            return View(deger);
        }
        public IActionResult EditLogo()
        {
            var deger = siteInfoRepository.GetFirst();
            return View(deger);
        }

        [HttpPost]
        public IActionResult EditLogo(SiteInfo siteInfo)
        {
            var deger = siteInfoRepository.TGet(1);
            deger.LogoUrl = siteInfo.LogoUrl;
            siteInfoRepository.TUpdate(deger);
            return View(deger);
        }
        public IActionResult EditAbout()
        {
            var info = siteInfoRepository.TGetInc(1);
            return View(info);
        }



        [HttpPost]
        public IActionResult EditAbout(SiteInfo siteInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(siteInfo);
            }
            siteInfoRepository.TUpdate(siteInfo);
            return View();
        }

        public IActionResult EditSiteAdress()
        {
            var address = siteAdressInfoRepository.TGetInc(1);
            return View(address);
        }

        [HttpPost]
        public IActionResult EditSiteAdress(SiteAdressInfo siteAdressInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(siteAdressInfo);
            }
            siteAdressInfoRepository.TUpdate(siteAdressInfo);
            return View();
        }
        public IActionResult Users()
        {
            var degerler = userInfoRepository.TList("User", "Price");
            return View(degerler);
        }

        public PartialViewResult Details()
        {

            return PartialView();
        }
        public IActionResult Delete(int id)
        {
            var user = userRepository.TGet(userInfoRepository.TGet(id).UserId);
            userRepository.TRemove(user);
            return RedirectToAction("Users");
        }

        public IActionResult PassiveUsers()
        {
            var degerler = userRepository.TGetPassives();
            return View(degerler);
        }
        public IActionResult MakeActive(int id)
        {
            var user = userRepository.TGet(id);
            user.IsActive = true;
            userRepository.TUpdate(user);
            return RedirectToAction("Users", "Admin");
        }
        public IActionResult AddUser()
        {

            ViewBag.degerler = dropDown();
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserInfo userInfo)
        {

            ViewBag.degerler = dropDown();
            if (!ModelState.IsValid)
            {
                ViewData["Hata"] = "Bir hata oluştu lütfen tüm alanları doldurduğunuzdan emin olunuz!";
                return View();
            }
            else
            {
                User user = new User();
                UserInfo send = new UserInfo();
                Revenue revenue = new Revenue();
                user.Email = userInfo.User.Email;
                user.Password = userInfo.User.Password;
                user.IsActive = true;

                userRepository.TAdd(user);

                send.Tc = userInfo.Tc;
                send.Name = userInfo.Name;
                send.Surname = userInfo.Surname;
                send.Phone = userInfo.Phone;
                send.Birthday = userInfo.Birthday;
                send.UserId = user.Id;
                send.PriceId = userInfo.PriceId;
                send.RegistrationDate = DateTime.Now;
                send.PlanStartDate = DateTime.Now;
                send.PlanEndDate = DateTime.Now.AddMonths(priceRepository.TGet(userInfo.PriceId).Months);
                userInfoRepository.TAdd(send);
                revenue.PriceValue = priceRepository.TGet(userInfo.PriceId).PriceValue;
                revenue.Month = DateTime.Now.Month.ToString();
                revenue.Year = DateTime.Now.Year.ToString();
                revenue.Description = priceRepository.TGet(userInfo.PriceId).Description;
                revenueRepository.TAdd(revenue);
                return RedirectToAction("Users");
            }

        }

        public IActionResult EditUser(int id)
        {
            ViewBag.degerler = dropDown();
            var user = userInfoRepository.TGetInc(id, includeProperties: "User");
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(UserInfo userInfo)
        {
            ViewBag.degerler = dropDown();

            User user = userRepository.TGet(userInfo.UserId); ;
            if (!ModelState.IsValid)
            {
                ViewData["Hata"] = "Bir hata oluştu lütfen tüm alanları doldurduğunuzdan emin olunuz!";
                return View();
            }
            else
            {
                user.Email = userInfo.User.Email;
                user.Password = userInfo.User.Password;

                try
                {

                    userRepository.TUpdate(user);


                    userInfo.User.Id = user.Id;

                    userInfoRepository.TUpdate(userInfo);
                    return RedirectToAction("Users");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewData["Hata"] = "Bir hata oluştu lütfen tüm alanları doldurduğunuzdan emin olunuz!";
                    return View();
                }
            }
        }

        public IActionResult SocialMediaEdit()
        {
            var deger = siteInfoRepository.TGet(1);
            return View(deger);

        }

        [HttpPost]
        public IActionResult SocialMediaEdit(SiteInfo siteInfo)
        {
            var deger = siteInfoRepository.TGet(1);
            deger.InstaUrl = siteInfo.InstaUrl;
            deger.FaceUrl = siteInfo.FaceUrl;
            deger.TwUrl = siteInfo.TwUrl;
            deger.YoutubeUrl = siteInfo.YoutubeUrl;
            siteInfoRepository.TUpdate(deger);
            return View(deger);

        }
    }
}
