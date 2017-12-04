namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngryBirdsDatabase.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AngryBirdsDatabase.MyContext";
        }

        protected override void Seed(AngryBirdsDatabase.MyContext context)
        {   

            context.Players.AddOrUpdate<Player> (new Player {PlayerName = "Camilla", PlayerKey = 1});
            var player1 = context.Players.Where(p => p.PlayerKey == 1).First();
        
            context.Levels.AddOrUpdate<Level> (new Level { Birds = 7, LevelNumber = 1});
            var level1 = context.Levels.Where(l => l.LevelKey == 1).First();

            context.Scores.AddOrUpdate<Score>(new Score { LevelScore = 1000, BirdsLeft = 2, Player = player1, Level = level1});
            context.SaveChanges();
            
            

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
          }
    }
}
