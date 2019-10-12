using HSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPS.ViewModels
{
    public class PatientResult
    {
        public Patient PatientInfo { get; set; }
        public Result Result { get; set; }
        public PatientResult(Patient PatientInfo, Result Result)
        {
            this.PatientInfo = PatientInfo;
            this.Result = Result;
        }

    }
}