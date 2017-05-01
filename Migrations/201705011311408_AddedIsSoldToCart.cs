namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSoldToCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "IsSold", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "IsSold");
        }
    }
}
