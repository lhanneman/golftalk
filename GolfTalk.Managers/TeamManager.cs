using GolfTalk.Contracts.Accessor;
using GolfTalk.Contracts.Manager;
using GolfTalk.DataContracts;

namespace GolfTalk.Managers
{
    public class TeamManager : ITeamManager
    {
        private readonly ITeamAccessor teamAccessor;

        public TeamManager(ITeamAccessor teamAccesor)
        {
            this.teamAccessor = teamAccesor;
        }

        public void AddUserToTeam(long teamId, string userId)
        {
            teamAccessor.AddUserToTeam(teamId, userId);
        }

        public Team Find(FindTeamRequest request)
        {
            return teamAccessor.Find(request);
        }

        public Team[] ListTeams()
        {
            return teamAccessor.ListTeams();
        }
    }
}
