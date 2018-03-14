namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletedproperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "CurrentLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "CurrentLevel", c => c.Int(nullable: false));
        }
    }
}
