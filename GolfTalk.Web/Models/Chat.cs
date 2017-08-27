using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTalk.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        [ForeignKey("Team")]
        public long TeamID { get; set; }
        public string Message { get; set; }
        public virtual Team Team { get; set; }
    }
}