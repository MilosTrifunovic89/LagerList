using Domain.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LagerListContext : DbContext
    {
        public LagerListContext()
        {

        }

        public DbSet<Panel> Panels { get; set; }
        public DbSet<Length> Lengths { get; set; }
        public DbSet<Width> Widths { get; set; }
        public DbSet<Thickness> Thicknesses { get; set; }
        public DbSet<Operater> Operaters { get; set; }
        public DbSet<TypeOfPanel> TypeOfPanels { get; set; }
        public DbSet<Workbench> Workbenchs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PanelConfiguration());
            modelBuilder.Configurations.Add(new OperaterConfiguration());
            modelBuilder.Configurations.Add(new LengthConfiguration());
            modelBuilder.Configurations.Add(new WidthConfiguration());
            modelBuilder.Configurations.Add(new ThicknessConfiguration());
            modelBuilder.Configurations.Add(new TypeConfiguration());
            modelBuilder.Configurations.Add(new WorkbenchConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
