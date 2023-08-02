using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMAP
{
    public class Mail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string HtmlBody { get; set; }

        public string From { get; set; }    
    }
}
