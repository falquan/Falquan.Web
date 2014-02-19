using Falquan.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Falquan.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact contact)
        {
            if (!ModelState.IsValid) return View(contact);

            var mail = new MailMessage(contact.Email, WebConfig.AppSettings.Contact.ContactEmail, string.Format("Form Submission - {0}", string.IsNullOrWhiteSpace(contact.Name) ? contact.Email : contact.Name), contact.Message);
            mail.ReplyToList.Add(contact.Email);

            using (var smtp = new SmtpClient())
            {
                smtp.Port = WebConfig.AppSettings.Contact.SmtpPort;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(WebConfig.AppSettings.Contact.SmtpUsername, WebConfig.AppSettings.Contact.SmtpPassword);
                smtp.Host = WebConfig.AppSettings.Contact.SmtpHostname;
                smtp.Send(mail);
            }
            
            return Redirect("/");
        }

        public ActionResult Throw()
        {
            throw new NotImplementedException();

            return View();
        }
    }
}
