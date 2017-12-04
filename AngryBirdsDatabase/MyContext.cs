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
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Scores)
                .WithRequired(s => s.Player);


            modelBuilder.Entity<Level>()
                .HasMany(l => l.Scores)
                .WithRequired(s => s.Level);
              
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Player> Players {get; set;}
        public DbSet<Level> Levels { get; set; }
        public DbSet<Score> Scores { get; set; }


    }
}
