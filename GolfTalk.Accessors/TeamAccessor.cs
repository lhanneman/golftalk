using GolfTalk.Contracts.Accessor;
using GolfTalk.DataContracts;
using System;
using System.Linq;
using System.Data.Entity;

namespace GolfTalk.Accessors
{
    public class TeamAccessor : ITeamAccessor
    {
        public void AddUserToTeam(long teamId, string userId)
        {
            throw new NotImplementedException();
        }

        public Team Find(FindTeamRequest request)
        {
            using (var db = new GolfContext())
            {
                //var teamId = (from t in db.Teams
                //              join tu in db.TeamUsers on t.Id equals tu.TeamId
                //              where tu.UserId == request.UserId
                //              select tu.TeamId).First();

                //var teams = db.Teams
                //    .Include(t => t.Scores)
                //    .Include(t => t.Scores.Select(s => s.Hole));

                //return teams.Where(t => t.Id == teamId).Select(t => new Team()
                //{
                //    Id = t.Id,
                //    Name = t.Name,
                //    Scores = t.Scores.Select(s => new Score()
                //    {
                //        HoleId = s.HoleId,
                //        Id = s.Id,
                //        Strokes = s.Strokes,
                //        TeamId = s.TeamId,
                //        Hole = new Hole()
                //        {
                //            HoleNumber = s.Hole.HoleNumber,
                //            Id = s.Hole.Id,
                //            Par = s.Hole.Par,
                //            Yards = s.Hole.Yards
                //        }
                //    }).ToArray()
                //}).First();

                return null;

            }
        }

        public Team[] ListTeams()
        {
            //using (var db = new GolfContext())
            //{
            //    var teams = db.Teams
            //        .Include(t => t.Scores)
            //        .Include(t => t.Scores.Select(s => s.Hole));

            //    return teams.Select(t => new Team()
            //    {
            //        Id = t.Id,
            //        Name = t.Name,
            //        Scores = t.Scores.Select(s => new Score()
            //        {
            //            HoleId = s.HoleId,
            //            Id = s.Id,
            //            Strokes = s.Strokes,
            //            TeamId = s.TeamId,
            //            Hole = new Hole()
            //            {
            //                HoleNumber = s.Hole.HoleNumber,
            //                Id = s.Hole.Id,
            //                Par = s.Hole.Par,
            //                Yards = s.Hole.Yards
            //            }
            //        }).ToArray()
            //    }).ToArray();
            //}

            return null;
        }
    }
}
