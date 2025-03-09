using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaint.Figures
{
    public class Ellipse: IFigure
    {
        public Ellipse(int firstRadius = 1, int secondRadius = 1, char color = '#', char backgroundColor = ' ')
        {
            Color = color;
            BackgroundColor = backgroundColor;
            FirstRadius = firstRadius;
            SecondRadius = secondRadius;
        }
        public char BackgroundColor { get; set; }
        public char Color { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int FirstRadius { get; set; }
        public int SecondRadius { get; set; }
        public String? Name { get; set; }
    }
}
