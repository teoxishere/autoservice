namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogEntryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Action = c.Int(nullable: false),
                        Username = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogEntries");
        }
    }
}
