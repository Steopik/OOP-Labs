using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaint.Figures
{
	class RightTriangle : IFigure
	{
        public RightTriangle(int length = 1, char color = '#', char backgroundColor = ' ')
		{
			Color = color;
			BackgroundColor = backgroundColor;
			Length = length;
		}
		public char Color { get; set; }
		public char BackgroundColor { get; set; }
		public int CenterX { get; set; }
		public int CenterY { get; set; }
		public int Length { get; set; }
		public String? Name { get; set; }
	}
}
