namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagesOnCarTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Content");
        }
    }
}
