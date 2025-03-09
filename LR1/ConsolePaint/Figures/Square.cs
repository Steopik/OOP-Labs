using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsolePaint.Figures
{
    public class Square: Rectangle
    {
        public Square(int length = 1, char color = '#', char backgroundColor = ' ')
            : base(length, length, color, backgroundColor)
        {}

        public Square(Square square)
        {
            this.Name = square.Name;
            this.CenterX = square.CenterX;
            this.CenterY = square.CenterY;
            this.Width = square.Width;
            this.Length = square.Length;
            this.Color = square.Color;
            this.BackgroundColor = square.BackgroundColor;
        }
    }
}
