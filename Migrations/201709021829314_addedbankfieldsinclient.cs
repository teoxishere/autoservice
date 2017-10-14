namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbankfieldsinclient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientOfParks", "BankAccount", c => c.String(unicode: false));
            AddColumn("dbo.ClientOfParks", "BankName", c => c.String(unicode: false));
            AddColumn("dbo.ClientOfParks", "J", c => c.String(unicode: false));
            DropColumn("dbo.ClientOfParks", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientOfParks", "PhoneNumber", c => c.String(unicode: false));
            DropColumn("dbo.ClientOfParks", "J");
            DropColumn("dbo.ClientOfParks", "BankName");
            DropColumn("dbo.ClientOfParks", "BankAccount");
        }
    }
}
