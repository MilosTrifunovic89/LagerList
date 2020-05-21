using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Length
    {
        public int Id { get; set; }

        public int PanelLength { get; set; }

        public ICollection<Panel> Panels { get; set; }

        public override string ToString()
        {
            return $"{PanelLength}";
        }
    }
}
