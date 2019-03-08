using System;
using System.ComponentModel.DataAnnotations;

namespace GolfTalk.Web.Models
{
    public class TournamentViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Time Zone")]
        public string TimeZone { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}