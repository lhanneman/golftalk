using GolfTalk.DataContracts;

namespace GolfTalk.Contracts.Manager
{
    public interface ITournamentManager
    {
        long AddTournament(AddTournamentRequest request);
    }
}
