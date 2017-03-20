namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCcToEngine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Engines", "Cc", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Engines", "Cc");
        }
    }
}
