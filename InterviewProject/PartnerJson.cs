using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject
{

    public class Rootobject
    {
        public Partner1[] partners { get; set; }
    }

    public class Partner1
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string[] availableDates { get; set; }
    }

    internal class PartnerJson
    {
    }
}
