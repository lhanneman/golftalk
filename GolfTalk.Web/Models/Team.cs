using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTalk.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TeamID { get; set; }
        public string Name { get; set; }
    }
}