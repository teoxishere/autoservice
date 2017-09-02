namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedissoldfromdetails : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartDetails", "IsSold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartDetails", "IsSold", c => c.Boolean(nullable: false));
        }
    }
}
