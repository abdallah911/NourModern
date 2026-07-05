using Microsoft.AspNetCore.Mvc;
using NourModern.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace NourModern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SendEmail(string applicationType, string fullName, string MatherName, string KidId, int age, string phone)
        {
            try
            {
                string to = "norhamdy998@gmail.com"; // Replace with recipient email address
                string subject = "طلب تقديم ";

                // Compose email message
                string emailMessage = $"نوع الطلب: {applicationType}\n";
                emailMessage += $"الاسم الكامل: {fullName}\n";
                emailMessage += $"اسم الام: {MatherName}\n";
                emailMessage += $"الرقم القومي للطفل: {KidId}\n";
                emailMessage += $"العمر: {age}\n";
                emailMessage += $"رقم الهاتف: {phone}\n";

                // Configure SMTP client
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("hrindemnity@gmail.com", "maadtyhyszskumob");

                // Create and send email
                using (MailMessage mailMessage = new MailMessage("nourmdrn@gmail.com", to, subject, emailMessage))
                    {
                        smtpClient.Send(mailMessage);
                    }
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
