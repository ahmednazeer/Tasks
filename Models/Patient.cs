using HPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HSP.Models
{
    public class Patient:ApplicationUser
    {
        public Patient():base()
        {

        }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Job { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}