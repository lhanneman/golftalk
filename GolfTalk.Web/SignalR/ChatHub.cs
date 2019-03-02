using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace GolfTalk.SignalR
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public static void Update(string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.updateFeed(message);
        }

        public static void UpdateScore(string teamId, int score, int thru)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.updateScore(teamId, score, thru);
        }
    }
}