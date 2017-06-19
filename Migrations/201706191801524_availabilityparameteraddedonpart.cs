namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availabilityparameteraddedonpart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "isAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "isAvailable");
        }
    }
}
