namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientphoneadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientOfParks", "Phone", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientOfParks", "Phone");
        }
    }
}
