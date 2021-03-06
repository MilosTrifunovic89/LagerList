﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TypeOfPanel
    {
        public int Id { get; set; }

        public string PanelType { get; set; }

        public ICollection<Panel> Panels { get; set; }

        public ICollection<Workbench> Workbenches { get; set; }

        public ICollection<Length> Lengths { get; set; }

        public ICollection<Width> Widths { get; set; }

        public ICollection<Thickness> Thicknesses { get; set; }

        public override string ToString()
        {
            return $"{PanelType}";
        }
    }
}
