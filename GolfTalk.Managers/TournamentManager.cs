using GolfTalk.Contracts.Accessor;
using GolfTalk.Contracts.Manager;
using GolfTalk.DataContracts;

namespace GolfTalk.Managers
{
    public class TournamentManager : ITournamentManager
    {
        private readonly ITournamentAccessor tournamentAccessor;

        public TournamentManager(ITournamentAccessor tournamentAccessor)
        {
            this.tournamentAccessor = tournamentAccessor;
        }

        public long AddTournament(AddTournamentRequest request)
        {
            return tournamentAccessor.AddTournament(request);
        }
    }
}
