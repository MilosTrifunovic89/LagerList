using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class WorkbenchConfiguration : EntityTypeConfiguration<Workbench>
    {
        public WorkbenchConfiguration()
        {
            HasKey(w => w.Id);

            Property(w => w.Name)
                .HasMaxLength(200)
                .IsRequired();

            Property(w => w.Quantity)
                .IsRequired();
        }
    }
}
