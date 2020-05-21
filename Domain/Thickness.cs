﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Thickness
    {
        public int Id { get; set; }

        public int PanelThickness { get; set; }

        public ICollection<Panel> Panels { get; set; }

        public override string ToString()
        {
            return $"{PanelThickness}";
        }
    }
}