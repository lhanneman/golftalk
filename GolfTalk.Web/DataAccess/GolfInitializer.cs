using GolfTalk.Models;
using System.Collections.Generic;

namespace GolfTalk.DataAccess
{
    public class GolfInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GolfContext>
    {
        protected override void Seed(GolfContext context)
        {

            // default data - update for whatever course you want

            context.Database.ExecuteSqlCommand("delete from Team");
            context.Database.ExecuteSqlCommand("delete from Hole");

            var holes = new List<Hole> {
                new Hole { HoleNumber = 1, Par = 5, Yards = 500 },
                new Hole { HoleNumber = 2, Par = 4, Yards = 358 },
                new Hole { HoleNumber = 3, Par = 3, Yards = 150 },
                new Hole { HoleNumber = 4, Par = 4, Yards = 314 },
                new Hole { HoleNumber = 5, Par = 4, Yards = 376 },
                new Hole { HoleNumber = 6, Par = 4, Yards = 393 },
                new Hole { HoleNumber = 7, Par = 4, Yards = 388 },
                new Hole { HoleNumber = 8, Par = 5, Yards = 482 },
                new Hole { HoleNumber = 9, Par = 3, Yards = 202 },
                new Hole { HoleNumber = 10, Par = 5, Yards = 487 },
                new Hole { HoleNumber = 11, Par = 4, Yards = 387 },
                new Hole { HoleNumber = 12, Par = 3, Yards = 188 },
                new Hole { HoleNumber = 13, Par = 4, Yards = 378 },
                new Hole { HoleNumber = 14, Par = 3, Yards = 170 },
                new Hole { HoleNumber = 15, Par = 4, Yards = 420 },
                new Hole { HoleNumber = 16, Par = 4, Yards = 331 },
                new Hole { HoleNumber = 17, Par = 4, Yards = 361 },
                new Hole { HoleNumber = 18, Par = 5, Yards = 535 }
            };

            //var teams = new List<Team>
            //{
            //    new Team { Name = "Team 1" },
            //    new Team { Name = "Team 2" },
            //    new Team { Name = "Team 3" },
            //    new Team { Name = "Team 4" },
            //};

            var teams = new List<Team>
            {
                new Team { Name = "I Hit TK" },
                new Team { Name = "Natural Hazards" },
                new Team { Name = "Tap Tap Tappers" },
                new Team { Name = "GET IN THE HOLE!" },
                new Team { Name = "Grip It and Sip It" },
            };

            holes.ForEach(h => context.Holes.Add(h));
            teams.ForEach(t => context.Teams.Add(t));

            context.SaveChanges();
            base.Seed(context);
        }
    }
}