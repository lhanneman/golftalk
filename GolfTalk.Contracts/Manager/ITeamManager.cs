using GolfTalk.DataContracts;

namespace GolfTalk.Contracts.Manager
{
    public interface ITeamManager
    {
        void AddUserToTeam(long teamId, string userId);
        Team[] ListTeams();
        Team Find(FindTeamRequest request);
    }
}
