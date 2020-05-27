using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Operater
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public ICollection<Panel> Panels { get; set; }

        public ICollection<Panel> UpdatedPanels { get; set; }

        public ICollection<Workbench> Workbenches { get; set; }

        public ICollection<Workbench> UpdatedWorkbenches { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }

        public Roles Role { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}
