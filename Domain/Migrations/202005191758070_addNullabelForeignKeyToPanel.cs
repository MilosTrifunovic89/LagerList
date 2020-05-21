namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullabelForeignKeyToPanel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Panels", "UpdateOperaterId", c => c.Int());
            CreateIndex("dbo.Panels", "UpdateOperaterId");
            AddForeignKey("dbo.Panels", "UpdateOperaterId", "dbo.Operaters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Panels", "UpdateOperaterId", "dbo.Operaters");
            DropIndex("dbo.Panels", new[] { "UpdateOperaterId" });
            DropColumn("dbo.Panels", "UpdateOperaterId");
        }
    }
}
