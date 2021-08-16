 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorrentBG.Helper;
using TorrentBG.Models.Contact;

using static TorrentBG.Data.DataConstants.Contact;

namespace TorrentBG.App.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel contact)
        {
            string content = "Name: " + contact.Name;
            content += "<br>Email: " + contact.Email;
            content += "<br>Message:" + contact.Message;

            if (!ModelState.IsValid)
            {
                return View(new ContactFormModel());
            }

            if (MailHelper.Send(contact.Email,EmailAddress,contact.Subject,content))
            {
                this.ViewBag.msg = "Success";
            }
            else
            {
                return RedirectToAction("Index", "Contacts");
            }
            return View();
        }
    }
}
