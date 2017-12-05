namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allowednulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Levels", "LevelNumber", c => c.Int());
            AlterColumn("dbo.Levels", "Birds", c => c.Int());
            AlterColumn("dbo.Scores", "BirdsLeft", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Scores", "BirdsLeft", c => c.Int(nullable: false));
            AlterColumn("dbo.Levels", "Birds", c => c.Int(nullable: false));
            AlterColumn("dbo.Levels", "LevelNumber", c => c.Int(nullable: false));
        }
    }
}
