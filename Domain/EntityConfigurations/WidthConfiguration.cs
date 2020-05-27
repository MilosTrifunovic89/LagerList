using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class WidthConfiguration : EntityTypeConfiguration<Width>
    {
        public WidthConfiguration()
        {
            HasMany(p => p.Panels)
                .WithRequired(w => w.Width)
                .HasForeignKey(w => w.WidthId);

            HasMany(w => w.Workbenches)
                .WithRequired(w => w.Width)
                .HasForeignKey(w => w.WidthId);
        }
    }
}
