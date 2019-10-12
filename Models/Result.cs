using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HSP.Models
{
    public class Result
    {
        public int ID { get; set; }
        public string Disease { get; set; }
        public string Description { get; set; }
        public string DoctorSignature { get; set; }
        public DateTime ExaminationDate { get; set; }
        [NotMapped]
        public DateTime PrintDate { get; set; }
        public string PatientID { get; set; }
        public Patient Patient { get; set; }

        //public DateTime MyProperty { get; set; }
    }
}