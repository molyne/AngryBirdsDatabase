namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletednumberlevels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Scores", "LevelScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Scores", "LevelScore", c => c.Int());
        }
    }
}
