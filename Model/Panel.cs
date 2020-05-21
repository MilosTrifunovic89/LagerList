using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Panel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int LengthId { get; set; }
        public Length Length { get; set; }
        public int WidthId { get; set; }
        public Width Width { get; set; }
        public int ThicknessId { get; set; }
        public Thickness Thickness { get; set; }
        public int Quantity { get; set; }
        public double PanelSurface { get; set; }
        public double SurfaceInTotal { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int OperaterId { get; set; }
        public Operater Operater { get; set; }
    }
}
