namespace GolfTalk.DataContracts
{
    public class Team
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Score[] Scores { get; set; }
    }
}