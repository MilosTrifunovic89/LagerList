namespace Domain.Migrations
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
                "dbo.Panels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LengthId = c.Int(nullable: false),
                        TypeOfPanelId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Operaters", t => t.OperaterId, cascadeDelete: true)
                .ForeignKey("dbo.Thicknesses", t => t.ThicknessId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfPanels", t => t.TypeOfPanelId, cascadeDelete: true)
                .ForeignKey("dbo.Widths", t => t.WidthId, cascadeDelete: true)
                .ForeignKey("dbo.Lengths", t => t.LengthId, cascadeDelete: true)
                .Index(t => t.LengthId)
                .Index(t => t.TypeOfPanelId)
                .Index(t => t.WidthId)
                .Index(t => t.ThicknessId)
                .Index(t => t.OperaterId);
            
            CreateTable(
                "dbo.Operaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 300),
                        Password = c.String(nullable: false, maxLength: 30),
                        DateCreated = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Thicknesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PanelThickness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfPanels",
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
            DropForeignKey("dbo.Panels", "LengthId", "dbo.Lengths");
            DropForeignKey("dbo.Panels", "WidthId", "dbo.Widths");
            DropForeignKey("dbo.Panels", "TypeOfPanelId", "dbo.TypeOfPanels");
            DropForeignKey("dbo.Panels", "ThicknessId", "dbo.Thicknesses");
            DropForeignKey("dbo.Panels", "OperaterId", "dbo.Operaters");
            DropIndex("dbo.Panels", new[] { "OperaterId" });
            DropIndex("dbo.Panels", new[] { "ThicknessId" });
            DropIndex("dbo.Panels", new[] { "WidthId" });
            DropIndex("dbo.Panels", new[] { "TypeOfPanelId" });
            DropIndex("dbo.Panels", new[] { "LengthId" });
            DropTable("dbo.Widths");
            DropTable("dbo.TypeOfPanels");
            DropTable("dbo.Thicknesses");
            DropTable("dbo.Operaters");
            DropTable("dbo.Panels");
            DropTable("dbo.Lengths");
        }
    }
}
