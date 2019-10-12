using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPS.Models
{
    public class Email
    {
        public string Reciever { get; } = "solutions@hps-global.net";
        public string Subject { get; set; }
        public string Message { get; set; }
        public string YourEmailPassword { get; set; }
    }
}