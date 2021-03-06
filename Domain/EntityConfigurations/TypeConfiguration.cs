﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntityConfigurations
{
    public class TypeConfiguration : EntityTypeConfiguration<TypeOfPanel>
    {
        public TypeConfiguration()
        {
            HasMany(p => p.Panels)
                .WithRequired(t => t.TypeOfPanel)
                .HasForeignKey(t => t.TypeOfPanelId);

            HasMany(w => w.Workbenches)
                .WithRequired(t => t.TypeOfPanel)
                .HasForeignKey(t => t.TypeOfPanelId);

            HasMany(l => l.Lengths)
                .WithMany(t => t.Types)
                .Map(m => m.ToTable("TypeLengths"));

            HasMany(w => w.Widths)
                .WithMany(t => t.Types)
                .Map(m => m.ToTable("TypeWidths"));

            HasMany(t => t.Thicknesses)
                .WithMany(t => t.Types)
                .Map(m => m.ToTable("TypeThicknesses"));
        }
    }
}
