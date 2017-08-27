namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientsAddedToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientOfParks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        RegNo = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientOfParks");
        }
    }
}
