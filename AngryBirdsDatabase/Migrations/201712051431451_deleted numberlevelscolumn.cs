namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletednumberlevelscolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Levels", "LevelNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Levels", "LevelNumber", c => c.Int());
        }
    }
}
