namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedallownulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Levels", "Birds", c => c.Int(nullable: false));
            AlterColumn("dbo.Scores", "BirdsLeft", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Scores", "BirdsLeft", c => c.Int());
            AlterColumn("dbo.Levels", "Birds", c => c.Int());
        }
    }
}
