using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp
{
     class MailService
    {
        public void OnVideoEncoded(object source, EventArgs e) {
            Console.WriteLine("MailService: video encoded - sending email");
        }
    }
}
