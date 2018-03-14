namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        Birds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ScoreId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        LevelScore = c.Int(nullable: false),
                        BirdsLeft = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScoreId)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        CurrentLevel = c.Int(nullable: false),
                        TotalScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.PlayerScores",
                c => new
                    {
                        Player_PlayerId = c.Int(nullable: false),
                        Score_ScoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_PlayerId, t.Score_ScoreId })
                .ForeignKey("dbo.Players", t => t.Player_PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Scores", t => t.Score_ScoreId, cascadeDelete: true)
                .Index(t => t.Player_PlayerId)
                .Index(t => t.Score_ScoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.PlayerScores", "Score_ScoreId", "dbo.Scores");
            DropForeignKey("dbo.PlayerScores", "Player_PlayerId", "dbo.Players");
            DropIndex("dbo.PlayerScores", new[] { "Score_ScoreId" });
            DropIndex("dbo.PlayerScores", new[] { "Player_PlayerId" });
            DropIndex("dbo.Scores", new[] { "LevelId" });
            DropTable("dbo.PlayerScores");
            DropTable("dbo.Players");
            DropTable("dbo.Scores");
            DropTable("dbo.Levels");
        }
    }
}
