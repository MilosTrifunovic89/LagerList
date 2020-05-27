namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLengthIdName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Workbenches", name: "LengyhId", newName: "LengthId");
            RenameIndex(table: "dbo.Workbenches", name: "IX_LengyhId", newName: "IX_LengthId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Workbenches", name: "IX_LengthId", newName: "IX_LengyhId");
            RenameColumn(table: "dbo.Workbenches", name: "LengthId", newName: "LengyhId");
        }
    }
}
