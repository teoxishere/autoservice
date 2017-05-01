namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        PriceOfPart = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, unicode: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartDetails", "PartId", "dbo.Parts");
            DropForeignKey("dbo.CartDetails", "CartId", "dbo.Carts");
            DropIndex("dbo.CartDetails", new[] { "PartId" });
            DropIndex("dbo.CartDetails", new[] { "CartId" });
            DropTable("dbo.Carts");
            DropTable("dbo.CartDetails");
        }
    }
}
