namespace GolfTalk.Accessors.Models
{
    internal class Chat
    {
        public int Id { get; set; }

        public long TeamId { get; set; }

        public string Message { get; set; }

        public virtual Team Team { get; set; }
    }
}