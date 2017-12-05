namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngryBirdsDatabase.MyContext>
    {
        Player player1 = new Player { PlayerName = "Camilla"};
        Player player2 = new Player { PlayerName = "Molyn" };
        Player player3 = new Player { PlayerName = "Joakim" };
        Level level1 = new Level { Birds = 7, LevelNumber = 1 };
        Level level2 = new Level { Birds =  10, LevelNumber = 2 };
        Level level3 = new Level { Birds = 5, LevelNumber = 3 };
        Level level4 = new Level { Birds = 6, LevelNumber = 4 };
        Level level5 = new Level { Birds = 9, LevelNumber = 5 };


        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AngryBirdsDatabase.MyContext";
        }

        protected override void Seed(AngryBirdsDatabase.MyContext context)
        {
            // Player Score Level 1

            Score player1ScoreLevel1 = new Score { LevelScore = 1000, BirdsLeft = 2, Player = player1, Level = level1 };

            Score player2ScoreLevel1 = new Score { LevelScore = 7000, BirdsLeft = 3, Player = player2, Level = level1 };

            Score player3ScoreLevel1 = new Score { LevelScore = 500, BirdsLeft = 0, Player = player3, Level = level1 };

            // Player Score Level 2

            Score player1ScoreLevel2 = new Score { LevelScore = 50000, BirdsLeft = 0, Player = player1, Level = level2 };

            Score player2ScoreLevel2 = new Score { LevelScore = 4000, BirdsLeft = 1, Player = player2, Level = level2 };

            Score player3ScoreLevel2 = new Score { LevelScore = 3000, BirdsLeft = 2, Player = player3, Level = level2 };

            // Player Score Level 3

            Score player1ScoreLevel3 = new Score { LevelScore = 8754, BirdsLeft = 3, Player = player1, Level = level3 };

            Score player2ScoreLevel3 = new Score { LevelScore = 10895, BirdsLeft = 4, Player = player2, Level = level3 };

            Score player3ScoreLevel3 = new Score { LevelScore = 0, BirdsLeft = 0, Player = player3, Level = level3 };

            //Player Score Level 4

            Score player1ScoreLevel4 = new Score { LevelScore = 12030, BirdsLeft = 1, Player = player1, Level = level4 };

            Score player2ScoreLevel4 = new Score { LevelScore = 4876, BirdsLeft = 0, Player = player2, Level = level4 };

            //Player Score Level 5

            Score player1ScoreLevel5 = new Score { LevelScore = 48760, BirdsLeft = 3, Player = player1, Level = level5 };


            context.Players.AddOrUpdate<Player> (player1);
            context.Players.AddOrUpdate<Player>(player2);
            context.Players.AddOrUpdate<Player>(player3);


            context.Levels.AddOrUpdate<Level>(level1);
            context.Levels.AddOrUpdate<Level>(level2);
            context.Levels.AddOrUpdate<Level>(level3);
            context.Levels.AddOrUpdate<Level>(level4);
            context.Levels.AddOrUpdate<Level>(level5);



            context.Scores.AddOrUpdate<Score>(player1ScoreLevel1);
            context.Scores.AddOrUpdate<Score>(player2ScoreLevel1);
            context.Scores.AddOrUpdate<Score>(player3ScoreLevel1);
            context.Scores.AddOrUpdate<Score>(player1ScoreLevel2);
            context.Scores.AddOrUpdate<Score>(player2ScoreLevel2);
            context.Scores.AddOrUpdate<Score>(player3ScoreLevel2);
            context.Scores.AddOrUpdate<Score>(player1ScoreLevel3);
            context.Scores.AddOrUpdate<Score>(player2ScoreLevel3);
            context.Scores.AddOrUpdate<Score>(player3ScoreLevel3);
            context.Scores.AddOrUpdate<Score>(player1ScoreLevel4);
            context.Scores.AddOrUpdate<Score>(player2ScoreLevel4);
            context.Scores.AddOrUpdate<Score>(player1ScoreLevel5);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
