using GolfTalk.Contracts.Accessor;
using GolfTalk.DataContracts;
using System.Linq;

namespace GolfTalk.Accessors
{
    public class ChatAccessor : IChatAccessor
    {
        public Chat[] ListChats()
        {
            using (var db = new GolfContext())
            {
                return db.Chats.Select(c => new Chat()
                {
                    Id = c.Id,
                    Message = c.Message,
                    TeamId = c.TeamId,
                    Team = new Team()
                    {
                        Id = c.Team.Id,
                        Name = c.Team.Name,
                        //Scores 
                    }
                }).ToArray();
            }
        }

        public void SaveMessage(long teamId, string message)
        {
            using (var db = new GolfContext())
            {
                var model = new Models.Chat()
                {
                    Message = message,
                    TeamId = teamId,
                };

                db.Chats.Add(model);
                db.SaveChanges();
            }
        }
    }
}
