using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GolfTalk.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TeamID { get; set; }
        public string Name { get; set; }
        public string TeamMembers { get; set; }
    }
}