using GolfTalk.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GolfTalk.DataAccess
{
    public class GolfContext : IdentityDbContext<ApplicationUser>
    {
        public GolfContext()
            : base("GolfContext", false)
        {
        }

        public static GolfContext Create()
        {
            return new GolfContext();
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}