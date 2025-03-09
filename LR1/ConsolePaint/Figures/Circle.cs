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
	}
}
