namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkBenchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workbenches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        TypeOfPanelId = c.Int(nullable: false),
                        LengyhId = c.Int(nullable: false),
                        WidthId = c.Int(nullable: false),
                        ThicknessId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalLength = c.Double(nullable: false),
                        InsertTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        OperaterId = c.Int(nullable: false),
                        UpdateOperaterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thicknesses", t => t.ThicknessId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfPanels", t => t.TypeOfPanelId, cascadeDelete: true)
                .ForeignKey("dbo.Widths", t => t.WidthId, cascadeDelete: true)
                .ForeignKey("dbo.Operaters", t => t.UpdateOperaterId)
                .ForeignKey("dbo.Operaters", t => t.OperaterId)
                .ForeignKey("dbo.Lengths", t => t.LengyhId, cascadeDelete: true)
                .Index(t => t.TypeOfPanelId)
                .Index(t => t.LengyhId)
                .Index(t => t.WidthId)
                .Index(t => t.ThicknessId)
                .Index(t => t.OperaterId)
                .Index(t => t.UpdateOperaterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workbenches", "LengyhId", "dbo.Lengths");
            DropForeignKey("dbo.Workbenches", "OperaterId", "dbo.Operaters");
            DropForeignKey("dbo.Workbenches", "UpdateOperaterId", "dbo.Operaters");
            DropForeignKey("dbo.Workbenches", "WidthId", "dbo.Widths");
            DropForeignKey("dbo.Workbenches", "TypeOfPanelId", "dbo.TypeOfPanels");
            DropForeignKey("dbo.Workbenches", "ThicknessId", "dbo.Thicknesses");
            DropIndex("dbo.Workbenches", new[] { "UpdateOperaterId" });
            DropIndex("dbo.Workbenches", new[] { "OperaterId" });
            DropIndex("dbo.Workbenches", new[] { "ThicknessId" });
            DropIndex("dbo.Workbenches", new[] { "WidthId" });
            DropIndex("dbo.Workbenches", new[] { "LengyhId" });
            DropIndex("dbo.Workbenches", new[] { "TypeOfPanelId" });
            DropTable("dbo.Workbenches");
        }
    }
}
