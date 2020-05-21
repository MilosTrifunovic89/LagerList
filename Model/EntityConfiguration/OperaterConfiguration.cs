using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityConfiguration
{
    public class OperaterConfiguration : EntityTypeConfiguration<Operater>
    {
        public OperaterConfiguration()
        {
            Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(30);

            Property(l => l.LastName)
                .IsRequired()
                .HasMaxLength(300);

            Property(r => r.Role)
                .IsRequired();
        }
    }
}
