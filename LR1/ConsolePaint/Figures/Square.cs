using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaint.Figures
{
    public class Square: Rectangle
    {
        public Square(int length = 1, char color = '#', char backgroundColor = ' ')
            : base(length, length, color, backgroundColor)
        {}
    }
}
