﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Models
{
    public class EMailMessage
    {
        public string[] Contacts { get; set; }
        public string[] Cc { get; set; }
        public string[] Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
