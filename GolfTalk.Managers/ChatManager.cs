using GolfTalk.Contracts.Accessor;
using GolfTalk.Contracts.Manager;
using GolfTalk.DataContracts;

namespace GolfTalk.Managers
{
    public class ChatManager : IChatManager
    {
        private readonly IChatAccessor chatAccessor;

        public ChatManager(IChatAccessor chatAccessor)
        {
            this.chatAccessor = chatAccessor;
        }

        public Chat[] ListChats()
        {
            return chatAccessor.ListChats();
        }

        public void SaveMessage(long tournamentId, string message, string sentByUserId)
        {
            chatAccessor.SaveMessage(tournamentId, message, sentByUserId);
        }
    }
}
