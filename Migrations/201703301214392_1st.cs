namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
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
                        Engine = c.String(unicode: false),
                        Fuel = c.String(unicode: false),
                        Body = c.String(unicode: false),
                        Oem_Code = c.String(unicode: false),
                        Year = c.DateTime(nullable: false, precision: 0),
                        Power = c.Double(nullable: false),
                        Capacity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Internal_Code = c.String(unicode: false),
                        BarCode = c.String(unicode: false),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Details = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Role = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
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
            DropForeignKey("dbo.PartCars", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.PartCars", "Part_Id", "dbo.Parts");
            DropIndex("dbo.PartCars", new[] { "Car_Id" });
            DropIndex("dbo.PartCars", new[] { "Part_Id" });
            DropTable("dbo.PartCars");
            DropTable("dbo.Users");
            DropTable("dbo.Parts");
            DropTable("dbo.Cars");
        }
    }
}
