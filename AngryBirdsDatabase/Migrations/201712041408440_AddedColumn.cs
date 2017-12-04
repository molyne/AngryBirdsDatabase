namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Levels", "LevelNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Levels", "LevelNumber");
        }
    }
}
