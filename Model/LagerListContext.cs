using Model.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
        public DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PanelConfiguration());
            modelBuilder.Configurations.Add(new OperaterConfiguration());

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
