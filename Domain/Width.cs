﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Width
    {
        public int Id { get; set; }

        public int PanelWidth { get; set; }

        public ICollection<Panel> Panels { get; set; }

        public ICollection<Workbench> Workbenches { get; set; }

        public ICollection<TypeOfPanel> Types { get; set; }

        public override string ToString()
        {
            return $"{PanelWidth}";
        }
    }
}
