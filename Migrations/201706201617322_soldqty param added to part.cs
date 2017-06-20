namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class soldqtyparamaddedtopart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "SoldQuantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "SoldQuantity");
        }
    }
}
