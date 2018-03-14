namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayerScores", "Player_PlayerKey", "dbo.Players");
            DropForeignKey("dbo.PlayerScores", "Score_ScoreKey", "dbo.Scores");
            DropIndex("dbo.PlayerScores", new[] { "Player_PlayerKey" });
            DropIndex("dbo.PlayerScores", new[] { "Score_ScoreKey" });
            AddColumn("dbo.Scores", "Player_PlayerKey", c => c.Int(nullable: false));
            CreateIndex("dbo.Scores", "Player_PlayerKey");
            AddForeignKey("dbo.Scores", "Player_PlayerKey", "dbo.Players", "PlayerKey", cascadeDelete: true);
            DropTable("dbo.PlayerScores");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerScores",
                c => new
                    {
                        Player_PlayerKey = c.Int(nullable: false),
                        Score_ScoreKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_PlayerKey, t.Score_ScoreKey });
            
            DropForeignKey("dbo.Scores", "Player_PlayerKey", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "Player_PlayerKey" });
            DropColumn("dbo.Scores", "Player_PlayerKey");
            CreateIndex("dbo.PlayerScores", "Score_ScoreKey");
            CreateIndex("dbo.PlayerScores", "Player_PlayerKey");
            AddForeignKey("dbo.PlayerScores", "Score_ScoreKey", "dbo.Scores", "ScoreKey", cascadeDelete: true);
            AddForeignKey("dbo.PlayerScores", "Player_PlayerKey", "dbo.Players", "PlayerKey", cascadeDelete: true);
        }
    }
}
