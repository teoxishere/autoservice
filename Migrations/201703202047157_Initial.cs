namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Versions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        EngineId = c.Int(nullable: false),
                        BodyId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bodies", t => t.BodyId, cascadeDelete: true)
                .ForeignKey("dbo.Engines", t => t.EngineId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.EngineId)
                .Index(t => t.BodyId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Versions", t => t.VersionId, cascadeDelete: true)
                .Index(t => t.VersionId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                        Quantity = c.Double(nullable: false),
                        Details = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Power = c.Int(nullable: false),
                        Fuel = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Makes", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Versions", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Versions", "EngineId", "dbo.Engines");
            DropForeignKey("dbo.Cars", "VersionId", "dbo.Versions");
            DropForeignKey("dbo.Parts", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Versions", "BodyId", "dbo.Bodies");
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropIndex("dbo.Parts", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "VersionId" });
            DropIndex("dbo.Versions", new[] { "BodyId" });
            DropIndex("dbo.Versions", new[] { "EngineId" });
            DropIndex("dbo.Versions", new[] { "ModelId" });
            DropTable("dbo.Makes");
            DropTable("dbo.Models");
            DropTable("dbo.Engines");
            DropTable("dbo.Parts");
            DropTable("dbo.Cars");
            DropTable("dbo.Versions");
            DropTable("dbo.Bodies");
        }
    }
}
