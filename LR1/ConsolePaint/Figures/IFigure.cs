using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaint.Figures
{
    interface IFigure
    {
        char Color { get; set; }
        char BackgroundColor { get; set; }
        int CenterX { get; set; }
        int CenterY { get; set; }
        String? Name { get; set; }
    }
}
