namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesKeyNames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scores", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.PlayerScores", "Score_ScoreId", "dbo.Scores");
            DropForeignKey("dbo.PlayerScores", "Player_PlayerId", "dbo.Players");
            RenameColumn(table: "dbo.Scores", name: "LevelId", newName: "Level_LevelKey");
            RenameColumn(table: "dbo.PlayerScores", name: "Player_PlayerId", newName: "Player_PlayerKey");
            RenameColumn(table: "dbo.PlayerScores", name: "Score_ScoreId", newName: "Score_ScoreKey");
            RenameIndex(table: "dbo.Scores", name: "IX_LevelId", newName: "IX_Level_LevelKey");
            RenameIndex(table: "dbo.PlayerScores", name: "IX_Player_PlayerId", newName: "IX_Player_PlayerKey");
            RenameIndex(table: "dbo.PlayerScores", name: "IX_Score_ScoreId", newName: "IX_Score_ScoreKey");
            DropPrimaryKey("dbo.Levels");
            DropPrimaryKey("dbo.Scores");
            DropPrimaryKey("dbo.Players");
            DropColumn("dbo.Levels", "LevelId");
            DropColumn("dbo.Scores", "ScoreId");
            DropColumn("dbo.Scores", "PlayerId");
            DropColumn("dbo.Players", "PlayerId");
            AddColumn("dbo.Levels", "LevelKey", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Scores", "ScoreKey", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Players", "PlayerKey", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Levels", "LevelKey");
            AddPrimaryKey("dbo.Scores", "ScoreKey");
            AddPrimaryKey("dbo.Players", "PlayerKey");
            AddForeignKey("dbo.Scores", "Level_LevelKey", "dbo.Levels", "LevelKey", cascadeDelete: true);
            AddForeignKey("dbo.PlayerScores", "Score_ScoreKey", "dbo.Scores", "ScoreKey", cascadeDelete: true);
            AddForeignKey("dbo.PlayerScores", "Player_PlayerKey", "dbo.Players", "PlayerKey", cascadeDelete: true);
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "PlayerId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Scores", "PlayerId", c => c.Int(nullable: false));
            AddColumn("dbo.Scores", "ScoreId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Levels", "LevelId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PlayerScores", "Player_PlayerKey", "dbo.Players");
            DropForeignKey("dbo.PlayerScores", "Score_ScoreKey", "dbo.Scores");
            DropForeignKey("dbo.Scores", "Level_LevelKey", "dbo.Levels");
            DropPrimaryKey("dbo.Players");
            DropPrimaryKey("dbo.Scores");
            DropPrimaryKey("dbo.Levels");
            DropColumn("dbo.Players", "PlayerKey");
            DropColumn("dbo.Scores", "ScoreKey");
            DropColumn("dbo.Levels", "LevelKey");
            AddPrimaryKey("dbo.Players", "PlayerId");
            AddPrimaryKey("dbo.Scores", "ScoreId");
            AddPrimaryKey("dbo.Levels", "LevelId");
            RenameIndex(table: "dbo.PlayerScores", name: "IX_Score_ScoreKey", newName: "IX_Score_ScoreId");
            RenameIndex(table: "dbo.PlayerScores", name: "IX_Player_PlayerKey", newName: "IX_Player_PlayerId");
            RenameIndex(table: "dbo.Scores", name: "IX_Level_LevelKey", newName: "IX_LevelId");
            RenameColumn(table: "dbo.PlayerScores", name: "Score_ScoreKey", newName: "Score_ScoreId");
            RenameColumn(table: "dbo.PlayerScores", name: "Player_PlayerKey", newName: "Player_PlayerId");
            RenameColumn(table: "dbo.Scores", name: "Level_LevelKey", newName: "LevelId");
            AddForeignKey("dbo.PlayerScores", "Player_PlayerId", "dbo.Players", "PlayerId", cascadeDelete: true);
            AddForeignKey("dbo.PlayerScores", "Score_ScoreId", "dbo.Scores", "ScoreId", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "LevelId", "dbo.Levels", "LevelId", cascadeDelete: true);
        }
    }
}
