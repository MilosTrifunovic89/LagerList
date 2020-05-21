namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeToNonNullabelForeignKeyToPanel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Panels", "OperaterId", "dbo.Operaters");
            DropIndex("dbo.Panels", new[] { "UpdateOperaterId" });
            AlterColumn("dbo.Panels", "UpdateOperaterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Panels", "UpdateOperaterId");
            AddForeignKey("dbo.Panels", "OperaterId", "dbo.Operaters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Panels", "OperaterId", "dbo.Operaters");
            DropIndex("dbo.Panels", new[] { "UpdateOperaterId" });
            AlterColumn("dbo.Panels", "UpdateOperaterId", c => c.Int());
            CreateIndex("dbo.Panels", "UpdateOperaterId");
            AddForeignKey("dbo.Panels", "OperaterId", "dbo.Operaters", "Id", cascadeDelete: true);
        }
    }
}
