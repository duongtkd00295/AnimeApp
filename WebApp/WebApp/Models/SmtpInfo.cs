using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class SmtpInfo
    {
        public string Smtp { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}