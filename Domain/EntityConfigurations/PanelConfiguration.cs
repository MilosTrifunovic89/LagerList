using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class PanelConfiguration : EntityTypeConfiguration<Panel>
    {
        public PanelConfiguration()
        {
            HasKey(p => p.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Quantity)
                .IsRequired();
        }
    }
}
