namespace GolfTalk.Accessors.Models
{
    internal class Team
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public  virtual Score[] Scores { get; set; }

    }
}