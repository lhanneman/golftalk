using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GolfTalk.Models
{
    public class TeamsScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Thru { get; set; }
        public Guid TeamID { get; set; }
        public string PlayerNames { get; set; }
    }
}