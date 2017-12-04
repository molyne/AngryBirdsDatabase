namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngryBirdsDatabase.MyContext>
    {
        Player player = new Player { PlayerName = "Camilla", PlayerKey = 1 };
        Level level = new Level { Birds = 7, LevelNumber = 1 };

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AngryBirdsDatabase.MyContext";
        }

        protected override void Seed(AngryBirdsDatabase.MyContext context)
        {   

            context.Players.AddOrUpdate<Player> (player);


            context.Levels.AddOrUpdate<Level>(level);

            context.Scores.AddOrUpdate<Score>(new Score { LevelScore = 1000, BirdsLeft = 2, Player = player, Level = level });




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
