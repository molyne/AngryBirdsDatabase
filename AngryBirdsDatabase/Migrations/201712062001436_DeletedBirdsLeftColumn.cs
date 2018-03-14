namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedBirdsLeftColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Scores", "BirdsLeft");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "BirdsLeft", c => c.Int(nullable: false));
        }
    }
}
