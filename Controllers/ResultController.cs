using HPS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using System.Threading.Tasks;

namespace HPS.Controllers
{
    [Authorize]
    public class ResultController : Controller
    {
        ApplicationDbContext context;
        public ResultController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Result
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var results =  context.Results.Where(res => res.PatientID == id);
            return View(results);
        }

        public ActionResult ViewReport(int id)
        {
            var result = context.Results.SingleOrDefault(res => res.ID==id);
            var patient = context.Patients.SingleOrDefault(p => p.Id == result.PatientID);
            result.Patient = patient;
            return View(result);
        }

        private ActionResult PrintedReport(int id)
        {
            var result = context.Results.SingleOrDefault(res => res.ID == id);
            var patient = context.Patients.SingleOrDefault(p => p.Id == result.PatientID);
            result.Patient = patient;
            return View(result);
        }

        public ActionResult Print(int id)
        {
            var result = context.Results.SingleOrDefault(r => r.ID == id);
            var patient = context.Patients.SingleOrDefault(p => p.Id == result.PatientID);
            result.Patient = patient;
            var res = new ViewAsPdf("PrintedReport",result);
            return res;
        }
    }
}