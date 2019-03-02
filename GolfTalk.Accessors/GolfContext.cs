using System.Data.Entity;
using GolfTalk.Accessors.Models;

namespace GolfTalk.Accessors
{
    internal class GolfContext : DbContext
    {
        static GolfContext()
        {
            Database.SetInitializer<GolfContext>(null);
        }

        public GolfContext() : base("GolfContext")
        {
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chat>().HasKey(m => m.Id);
            modelBuilder.Entity<Hole>().HasKey(m => m.Id);
            modelBuilder.Entity<Team>().HasKey(m => m.Id);
            modelBuilder.Entity<Score>().HasKey(m => m.Id);
            modelBuilder.Entity<TeamUser>().HasKey(m => m.Id);
        }
    }
}