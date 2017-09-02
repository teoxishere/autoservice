namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flagonclient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientOfParks", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientOfParks", "IsActive");
        }
    }
}
