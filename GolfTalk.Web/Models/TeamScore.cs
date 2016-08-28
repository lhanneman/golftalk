namespace GolfTalk.Models
{
    public class TeamsScore
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Thru { get; set; }
        public long TeamID { get; set; }
        public string PlayerNames { get; set; }
    }
}