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
        

        public MyContext(string ConnectionString) : base(ConnectionString) { }

        public DbSet<Player> Players {get; set;}
        public DbSet<Level> Levels { get; set; }
        public DbSet<Score> Scores { get; set; }


    }
}
