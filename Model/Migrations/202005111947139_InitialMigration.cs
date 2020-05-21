namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lengths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelLength = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 300),
                        Password = c.String(nullable: false, maxLength: 30),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Panels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TypeId = c.Int(nullable: false),
                        LengthId = c.Int(nullable: false),
                        WidthId = c.Int(nullable: false),
                        ThicknessId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PanelSurface = c.Double(nullable: false),
                        SurfaceInTotal = c.Double(nullable: false),
                        InsertTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        OperaterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lengths", t => t.LengthId, cascadeDelete: true)
                .ForeignKey("dbo.Operaters", t => t.OperaterId, cascadeDelete: true)
                .ForeignKey("dbo.Thicknesses", t => t.ThicknessId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Widths", t => t.WidthId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.LengthId)
                .Index(t => t.WidthId)
                .Index(t => t.ThicknessId)
                .Index(t => t.OperaterId);
            
            CreateTable(
                "dbo.Thicknesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelThickness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Widths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelWidth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Panels", "WidthId", "dbo.Widths");
            DropForeignKey("dbo.Panels", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Panels", "ThicknessId", "dbo.Thicknesses");
            DropForeignKey("dbo.Panels", "OperaterId", "dbo.Operaters");
            DropForeignKey("dbo.Panels", "LengthId", "dbo.Lengths");
            DropIndex("dbo.Panels", new[] { "OperaterId" });
            DropIndex("dbo.Panels", new[] { "ThicknessId" });
            DropIndex("dbo.Panels", new[] { "WidthId" });
            DropIndex("dbo.Panels", new[] { "LengthId" });
            DropIndex("dbo.Panels", new[] { "TypeId" });
            DropTable("dbo.Widths");
            DropTable("dbo.Types");
            DropTable("dbo.Thicknesses");
            DropTable("dbo.Panels");
            DropTable("dbo.Operaters");
            DropTable("dbo.Lengths");
        }
    }
}
