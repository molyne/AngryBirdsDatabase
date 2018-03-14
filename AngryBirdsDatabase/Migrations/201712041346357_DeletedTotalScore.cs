namespace AngryBirdsDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedTotalScore : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "TotalScore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "TotalScore", c => c.Int(nullable: false));
        }
    }
}
