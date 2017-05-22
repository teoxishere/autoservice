namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coloraddedtopart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "Color", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "Color");
        }
    }
}
