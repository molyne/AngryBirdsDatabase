using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AngryBirdsDatabase
{
    class MyContext : DbContext
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirdsDatabase.MyContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MyContext() : base() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var scoreConfig = modelBuilder.Entity<Score>();
            var levelConfiq = modelBuilder.Entity<Level>();

            modelBuilder.Entity<Player>().HasMany(p => p.Scores).WithRequired(s => s.Player);


            levelConfiq.HasMany(l => l.Scores).WithRequired(s => s.Level);
            levelConfiq.Property(l => l.LevelNumber).IsOptional();
            levelConfiq.Property(l => l.Birds).IsOptional();

            scoreConfig.Property(s => s.BirdsLeft).IsOptional();




            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Player> Players {get; set;}
        public DbSet<Level> Levels { get; set; }
        public DbSet<Score> Scores { get; set; }


    }
}
