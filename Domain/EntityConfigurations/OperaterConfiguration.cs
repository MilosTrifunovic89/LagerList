using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class OperaterConfiguration : EntityTypeConfiguration<Operater>
    {
        public OperaterConfiguration()
        {
            HasKey(o => o.Id);

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

            HasMany(p => p.Panels)
                .WithRequired(o => o.Operater)
                .HasForeignKey(o => o.OperaterId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.UpdatedPanels)
                .WithRequired(o => o.UpdateOperater)
                .HasForeignKey(o => o.UpdateOperaterId)
                .WillCascadeOnDelete(false);
        }
    }
}
