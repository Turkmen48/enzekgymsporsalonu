using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContact : Controller
    {
        ContactRepository contactRepository = new ContactRepository();
        EmailSettingRepository emailSettingRepository = new EmailSettingRepository();
        SiteInfoRepository siteInfo = new SiteInfoRepository();

        string htmlEmail(string siteadi, string cevaplancak, string mesaj)
        {
            return $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Merhaba!</title>\r\n</head>\r\n<body>\r\n    <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n        <tr>\r\n            <td style=\"background-color: #f8f8f8; text-align: center; padding: 40px 0;\">\r\n                <h1 style=\"color: #333333;\">Sorun Cevaplandı!</h1>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td style=\"padding: 20px;\">\r\n                <p>Merhaba,</p>\r\n                <p>Öncelikle bizimle iletişime geçtiğiniz için teşekkürler.</p>\r\n                <p>Senin Mesajın:</p>\r\n                <p>'{cevaplancak}'</p>\r\n                <br/>\r\n                <p>Site Yöneticisinin Cevabı:</p>\r\n                <p>{mesaj}</p>\r\n                <p>Saygılarımızla,</p>\r\n                <p>{siteadi}</p>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>\r\n";
        }
        public IActionResult Index()
        {
            var degerler = contactRepository.TList();
            return View(degerler);
        }

        public IActionResult Delete(int id)
        {
            var deger = contactRepository.TGet(id);
            contactRepository.TRemove(deger);
            return RedirectToAction("Index", "AdminContact");
        }

        public IActionResult AddEmailSetting()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmailSetting(EmailSetting emailSetting)
        {
            try
            {
                emailSettingRepository.TAdd(emailSetting);
                TempData["Message"] = "Email adresi başarıyla eklendi!";
                return RedirectToAction("EditEmailSettings", "AdminContact");
            }
            catch (Exception ex)
            {
                ViewData["Hata"] = "Bir hata oluştu lütfen tüm alanları doldurduğunuzdan emin olunuz! " + ex.Message;
                return View();
            }
        }

        public IActionResult EditEmailSettings()
        {
            var deger = emailSettingRepository.GetFirst();
            if (deger != null)
            {
                return View(deger);

            }

            return RedirectToAction("AddEmailSetting", "AdminContact");

        }

        [HttpPost]
        public IActionResult EditEmailSettings(EmailSetting emailSetting)
        {
            try
            {
                emailSettingRepository.TUpdate(emailSetting);
                TempData["Message"] = "Email adresi başarıyla düzenlendi!";
                return RedirectToAction("EditEmailSettings", "AdminContact");
            }
            catch (Exception ex)
            {
                var deger = emailSettingRepository.GetFirst();
                ViewData["Hata"] = "Bir hata oluştu lütfen tüm alanları doldurduğunuzdan emin olunuz! " + ex.Message;
                return View(deger);
            }

        }

        public IActionResult MarkRead(int id)
        {
            var deger = contactRepository.TGet(id);
            deger.IsRead = true;
            contactRepository.TUpdate(deger);
            return RedirectToAction("Index", "AdminContact");
        }

        public IActionResult Reply(int id)
        {
            var deger = contactRepository.TGet(id);
            return View(deger);
        }

        [HttpPost]
        public IActionResult Reply(string message, int id)
        {
            var deger = contactRepository.TGet(id);
            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    string title = siteInfo.GetFirst().SiteName;
                    string email = emailSettingRepository.GetFirst().Email;
                    string smtpaddress = emailSettingRepository.GetFirst().SmtpAddress;
                    string password = emailSettingRepository.GetFirst().Password;
                    int port = Convert.ToInt32(emailSettingRepository.GetFirst().Port);
                    string htmlBody = emailSettingRepository.GetFirst().EmailTemplate;

                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress(title, email);
                    MailboxAddress mailboxAddressTo = new MailboxAddress(deger.Email, deger.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = htmlEmail(title, deger.Message, message);
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = $"{title} Yöneticisi Tarafından Sorunuz Cevaplandı!";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect(smtpaddress, port, false);
                    smtpClient.Authenticate(email, password);
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                    TempData["Message"] = $"Mesajınız başarıyla gönderildi!";
                    return RedirectToAction("Reply", "AdminContact");
                }
                else
                {
                    ViewData["Hata"] = "Mesaj kısmı boş olamaz!";
                    return View(deger);
                }
            }
            catch (Exception ex)
            {
                ViewData["Hata"] = "Üzgünüz emailiniz gönderilirken bir hata oluştu! Lütfen Site işlemleri>Email Ayarları kısmından gerekli ayarları yaptığınızdan emin olunuz!" + ex.Message;
                return View(message, deger);
            }
        }
    }
}
