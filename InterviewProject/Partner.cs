using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InterviewProject
{
    class Partner : IComparable<Partner>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public List<string> availableDates { get; set; } = new List<string>();

        // : IComparable<Partner>
        public int CompareTo(Partner p)
        {
            if (country == p.country)
            {
                if (availableDates.Count > 0 && p.availableDates.Count > 0)
                {
                    return availableDates[0].CompareTo(p.availableDates[0]);
                }
                else { return -1; }
            }
            else { return country.CompareTo(p.country); }

        }
    }

    class Attendees
    {
        public int attendeeCount;
        public List<string> attendees;
        public string name;
        public string startDate;
    }

    class AttendeeList {
        //[JsonProperty("countries")]
        public List<Attendees> countries = new List<Attendees>();
    }


    class PartnerList
    {
        [JsonProperty("partners")]
        public List<Partner> partners { get; set; }

        public List<Partner> getPartners(string date1, string datenext, Dictionary<string, List<Partner>> map)
        {
            List<Partner> partners = new List<Partner>();
            foreach (var p1 in map[date1])
            {
                if (map.ContainsKey(datenext))
                {
                    foreach (var p11 in map[datenext])
                    {
                        if (p1.email == p11.email)
                        {
                            partners.Add(p1);
                        }
                    }
                }
            }
            return partners;
        }

        public AttendeeList GetEventPartners()
        {
            AttendeeList attendeeList = new AttendeeList();
            Dictionary<string, List<Partner>> map;
            //Dictionary<string, List<Partner>> validPartners = new Dictionary<string, List<Partner>>();
            
            int i1 = 0;
            string country = "";
            
            while (i1 < partners.Count)
            {
                country = partners[i1].country;
                map = new Dictionary<string, List<Partner>>();
                Dictionary<string, List<string>> partnerDate = new Dictionary<string, List<string>>();
                List<string> availableDates = new List<string>();
                
                while (i1 < partners.Count && partners[i1].country == country)
                {

                    for (int i11 = 0; i11 < partners[i1].availableDates.Count; i11++)
                    {
                        availableDates.Add(partners[i1].availableDates[i11]);

                        if (map.ContainsKey(partners[i1].availableDates[i11]))
                        {
                            map[partners[i1].availableDates[i11]].Add(partners[i1]);
                        }
                        else
                        {
                            map.Add(partners[i1].availableDates[i11], new List<Partner>() { partners[i1] });
                        }
                    }
                    i1++;
                }

                List<Partner> invitepartners = null;
                int count = 0;
                string inviteDate = "";
                for (int i11 = 0; i11 < availableDates.Count; i11++)
                {
                    string date1 = availableDates[i11];
                    string datenext = DateOnly.Parse(date1).AddDays(1).ToString("yyyy-MM-dd");
                    List<Partner> partners = getPartners(date1, datenext, map);
                    if (partners.Count > count)
                    {
                        count = partners.Count;
                        invitepartners = partners;
                        inviteDate = date1;
                    }
                }


                Attendees attendees = new Attendees();
                attendees.startDate = inviteDate;
                attendees.name = country;
                attendees.attendeeCount = invitepartners.Count;
                attendees.attendees = new List<string>();
                foreach (var p in invitepartners)
                {
                    attendees.attendees.Add(p.email);
                }

                attendeeList.countries.Add(attendees);


            }

            return attendeeList;
        }
    }
}
