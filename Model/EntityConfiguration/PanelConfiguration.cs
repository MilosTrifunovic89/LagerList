using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityConfiguration
{
    public class PanelConfiguration : EntityTypeConfiguration<Panel>
    {
        public PanelConfiguration()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Quantity)
                .IsRequired();

            HasRequired(o => o.Operater)
                .WithMany(p => p.Panels)
                .HasForeignKey(o => o.OperaterId);

        }
    }
}
