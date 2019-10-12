using HPS.Models;
using HSP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HPS.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        ApplicationDbContext context;

        public PatientController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Patient
        public  ActionResult Profile()
        {
            var username= User.Identity.GetUserName();
            string id = User.Identity.GetUserId();
            var user = context.Patients.SingleOrDefault(u => u.Id == id);
            return View(user);
        }
        public ActionResult Edit()
        {
            string id = User.Identity.GetUserId();
            var user = context.Patients.SingleOrDefault(u => u.Id == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Patient model)
        {
            string id = model.Id;
            var patient= context.Patients.SingleOrDefault(p => p.Id == id);
            if (patient != null) {
                patient.Job = model.Job;
                patient.Address = model.Address;
                patient.BirthDate = model.BirthDate;

                patient.UserName = model.UserName;
                patient.Email = model.Email;
                patient.PhoneNumber = model.PhoneNumber;
                context.SaveChanges();
                }
            return RedirectToAction("Profile");
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Email email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = User.Identity.GetUserId();
                    var user = context.Patients.SingleOrDefault(us => us.Id == id);
                    var senderEmail = new MailAddress(/*user.Email*/"ahmad.nazeergg45@gmail.com", user.UserName);
                    var receiverEmail = new MailAddress(email.Reciever, "Receiver");
                    var password = email.YourEmailPassword;
                    var sub = email.Subject;
                    var body = email.Message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
            //return View();
        }
        
    }
}