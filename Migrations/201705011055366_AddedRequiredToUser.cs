namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(unicode: false));
            AlterColumn("dbo.Users", "Username", c => c.String(unicode: false));
        }
    }
}
