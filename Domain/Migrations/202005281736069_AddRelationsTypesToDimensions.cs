namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationsTypesToDimensions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeLengths",
                c => new
                    {
                        TypeOfPanel_Id = c.Int(nullable: false),
                        Length_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeOfPanel_Id, t.Length_Id })
                .ForeignKey("dbo.TypeOfPanels", t => t.TypeOfPanel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lengths", t => t.Length_Id, cascadeDelete: true)
                .Index(t => t.TypeOfPanel_Id)
                .Index(t => t.Length_Id);
            
            CreateTable(
                "dbo.TypeThicknesses",
                c => new
                    {
                        TypeOfPanel_Id = c.Int(nullable: false),
                        Thickness_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeOfPanel_Id, t.Thickness_Id })
                .ForeignKey("dbo.TypeOfPanels", t => t.TypeOfPanel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Thicknesses", t => t.Thickness_Id, cascadeDelete: true)
                .Index(t => t.TypeOfPanel_Id)
                .Index(t => t.Thickness_Id);
            
            CreateTable(
                "dbo.TypeWidths",
                c => new
                    {
                        TypeOfPanel_Id = c.Int(nullable: false),
                        Width_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TypeOfPanel_Id, t.Width_Id })
                .ForeignKey("dbo.TypeOfPanels", t => t.TypeOfPanel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Widths", t => t.Width_Id, cascadeDelete: true)
                .Index(t => t.TypeOfPanel_Id)
                .Index(t => t.Width_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeWidths", "Width_Id", "dbo.Widths");
            DropForeignKey("dbo.TypeWidths", "TypeOfPanel_Id", "dbo.TypeOfPanels");
            DropForeignKey("dbo.TypeThicknesses", "Thickness_Id", "dbo.Thicknesses");
            DropForeignKey("dbo.TypeThicknesses", "TypeOfPanel_Id", "dbo.TypeOfPanels");
            DropForeignKey("dbo.TypeLengths", "Length_Id", "dbo.Lengths");
            DropForeignKey("dbo.TypeLengths", "TypeOfPanel_Id", "dbo.TypeOfPanels");
            DropIndex("dbo.TypeWidths", new[] { "Width_Id" });
            DropIndex("dbo.TypeWidths", new[] { "TypeOfPanel_Id" });
            DropIndex("dbo.TypeThicknesses", new[] { "Thickness_Id" });
            DropIndex("dbo.TypeThicknesses", new[] { "TypeOfPanel_Id" });
            DropIndex("dbo.TypeLengths", new[] { "Length_Id" });
            DropIndex("dbo.TypeLengths", new[] { "TypeOfPanel_Id" });
            DropTable("dbo.TypeWidths");
            DropTable("dbo.TypeThicknesses");
            DropTable("dbo.TypeLengths");
        }
    }
}
