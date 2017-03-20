namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVersionName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Versions", "Name", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Versions", "Name");
        }
    }
}
