using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class ThicknessConfiguration : EntityTypeConfiguration<Thickness>
    {
        public ThicknessConfiguration()
        {
            HasMany(p => p.Panels)
                .WithRequired(t => t.Thickness)
                .HasForeignKey(t => t.ThicknessId);
        }
    }
}
