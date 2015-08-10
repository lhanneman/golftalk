using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GolfTalk.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        public Guid TeamID { get; set; }
        public string Message { get; set; }
        public virtual Team Team { get; set; }
    }
}