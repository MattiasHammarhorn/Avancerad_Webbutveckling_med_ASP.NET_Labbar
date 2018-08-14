using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegisterDatabase.Models
{
    public class MailConfiguration
    {
        public string Mail { get; set; }
        public bool SendMail { get; set; }
        public bool LogEverySentMail { get; set; }
        public string[] BlindCopyAddresses { get; set; }
    }
}
