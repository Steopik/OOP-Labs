using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaint.Figures
{
	public class Circle: Ellipse
	{
		public Circle(int radius = 1, char color = '#', char backgroundColor = ' ')
			: base(radius, radius, color, backgroundColor)
		{}

		public Circle(Circle circle)
		{
			this.Name = circle.Name;
			this.CenterX = circle.CenterX;
			this.CenterY = circle.CenterY;
			this.FirstRadius = circle.FirstRadius;
			this.SecondRadius = circle.SecondRadius;
			this.Color = circle.Color;
			this.BackgroundColor = circle.BackgroundColor;
		}
	}
}
