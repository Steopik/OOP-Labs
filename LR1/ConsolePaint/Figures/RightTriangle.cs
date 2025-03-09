using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

		public RightTriangle(RightTriangle rightTriangle)
		{
            this.Name = rightTriangle.Name;
            this.CenterX = rightTriangle.CenterX;
            this.CenterY = rightTriangle.CenterY;
            this.Length = rightTriangle.Length;
            this.Color = rightTriangle.Color;
            this.BackgroundColor = rightTriangle.BackgroundColor;
        }
		public char Color { get; set; }
		public char BackgroundColor { get; set; }
		public int CenterX { get; set; }
		public int CenterY { get; set; }
		public int Length { get; set; }
		public String? Name { get; set; }
	}
}
