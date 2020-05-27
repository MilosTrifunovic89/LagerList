using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Workbench
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeOfPanelId { get; set; }
        public TypeOfPanel TypeOfPanel { get; set; }

        public int LengthId { get; set; }
        public Length Length { get; set; }

        public int WidthId { get; set; }
        public Width Width { get; set; }

        public int ThicknessId { get; set; }
        public Thickness Thickness { get; set; }

        public int Quantity { get; set; }

        public double TotalLength { get; set; }

        public DateTime InsertTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public int OperaterId { get; set; }
        public Operater Operater { get; set; }

        public int UpdateOperaterId { get; set; }
        public Operater UpdateOperater { get; set; }
    }
}
