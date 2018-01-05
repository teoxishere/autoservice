namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(unicode: false),
                        Model = c.String(unicode: false),
                        Fuel = c.String(unicode: false),
                        Body = c.String(unicode: false),
                        Internal_Code = c.String(unicode: false),
                        Year = c.Int(nullable: false),
                        Power = c.Double(nullable: false),
                        Capacity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Oem_Code = c.String(unicode: false),
                        BarCode = c.String(unicode: false),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Details = c.String(unicode: false),
                        Color = c.String(unicode: false),
                        SoldQuantity = c.Double(nullable: false),
                        InStock = c.Boolean(nullable: false),
                        isAvailable = c.Boolean(nullable: false),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PartId = c.Int(),
                        Price = c.Double(nullable: false),
                        ServiceDescription = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId)
                .Index(t => t.CartId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, unicode: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        IsSold = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientOfParks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        RegNo = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        BankAccount = c.String(unicode: false),
                        BankName = c.String(unicode: false),
                        J = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        Phone = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogEntries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Action = c.Int(nullable: false),
                        Username = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Price = c.Double(nullable: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartCars",
                c => new
                    {
                        Part_Id = c.Int(nullable: false),
                        Car_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Part_Id, t.Car_Id })
                .ForeignKey("dbo.Parts", t => t.Part_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .Index(t => t.Part_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartDetails", "PartId", "dbo.Parts");
            DropForeignKey("dbo.CartDetails", "CartId", "dbo.Carts");
            DropForeignKey("dbo.PartCars", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.PartCars", "Part_Id", "dbo.Parts");
            DropIndex("dbo.PartCars", new[] { "Car_Id" });
            DropIndex("dbo.PartCars", new[] { "Part_Id" });
            DropIndex("dbo.CartDetails", new[] { "PartId" });
            DropIndex("dbo.CartDetails", new[] { "CartId" });
            DropTable("dbo.PartCars");
            DropTable("dbo.Users");
            DropTable("dbo.LogEntries");
            DropTable("dbo.ClientOfParks");
            DropTable("dbo.Carts");
            DropTable("dbo.CartDetails");
            DropTable("dbo.Parts");
            DropTable("dbo.Cars");
        }
    }
}
