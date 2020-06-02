namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SqlQuerry : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Lengths (PanelLength) values (2800) ,(2750), (4100)");
            Sql("insert into Widths (PanelWidth) values (2070), (2050), (600)");
            Sql("insert into Thicknesses (PanelThickness) values (3), (18), (38)");
            Sql("insert into TypeOfPanels (PanelType) values ('Iverica'), ('MDF'), ('Lesonit'), ('Radna Ploca')");
            Sql("insert into TypeLengths (TypeOfPanel_Id, Length_Id) values (1,1),(1,2),(2,1),(2,2),(3,1),(3,2),(4,3)");
            Sql("insert into TypeWidths (TypeOfPanel_Id, Width_Id) values (1,1),(1,2),(2,1),(2,2),(3,1),(3,2),(4,3)");
            Sql("insert into TypeThicknesses (TypeOfPanel_Id, Thickness_Id) values (1,2),(2,2),(3,1),(4,3)");
            Sql("insert into Operaters (Name, LastName, Password, Role, DateCreated) values ('Milos', 'Trifunovic', 'MILOS', 1, CONVERT(datetime, '200505'))");
        }

        public override void Down()
        {
        }
    }
}
