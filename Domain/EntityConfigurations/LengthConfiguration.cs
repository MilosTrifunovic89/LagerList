using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class LengthConfiguration : EntityTypeConfiguration<Length>
    {
        public LengthConfiguration()
        {
            HasMany(p => p.Panels)
                .WithRequired(l => l.Length)
                .HasForeignKey(l => l.LengthId);
        }
    }
}
