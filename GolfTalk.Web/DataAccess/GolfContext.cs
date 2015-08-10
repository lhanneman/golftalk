using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GolfTalk.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GolfTalk.DataAccess
{
    public class GolfContext : DbContext
    {

        public GolfContext() : base("GolfContext") { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}