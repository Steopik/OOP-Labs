using ConsolePaint.Figures;


namespace ConsolePaint
{
	class Drawer
	{
		List<IFigure> Figures;
		int width;
		int height;
		public Drawer(int width, int height)
		{
			this.width = width;
			this.height = height;
			Figures = new List<IFigure>();
		}

        public Drawer(int width, int height, List<IFigure> figures)
        {
            this.width = width;
            this.height = height;
			Figures = figures;
        }

        public bool DrawEllipse(int firstRadius, int secondRadius, char color = '#', char backgroundColor = ' ', string name = "None")
		{
			if (2 * firstRadius > width || 2 * secondRadius > height) return false;

			Ellipse ellipse = new Ellipse(firstRadius, secondRadius);
			ellipse.CenterX = width / 2;
			ellipse.CenterY = height / 2;
			ellipse.Name = name;
			ellipse.Color = color;
			ellipse.BackgroundColor = backgroundColor;

			if (DrawEllipse(ellipse))
			{
				Figures.Add(ellipse);
				return true;
			}
			return false;
		}

		public bool DrawCircle(int radius, char color = '#', char backgroundColor = ' ', string name = "None")
		{
			if (2 * radius > width || 2 * radius > height) return false;

			Circle circle = new Circle(radius);
			circle.CenterX = width / 2;
			circle.CenterY = height / 2;
			circle.Name = name;
			circle.Color = color;
			circle.BackgroundColor = backgroundColor;

			if (DrawEllipse(circle))
			{
				Figures.Add(circle);
				return true;
			}
			return false;
		}

		bool DrawEllipse(Ellipse ellipse)
		{
			try
			{
				Console.SetCursorPosition(ellipse.CenterX, ellipse.CenterY - ellipse.SecondRadius);
				for (int y = Console.CursorTop; y <= ellipse.CenterY; y++)
				{
					int offsetY = ellipse.CenterY - y;
					int offsetX = (int)Math.Sqrt((1 - Math.Pow(offsetY, 2) / Math.Pow(ellipse.SecondRadius, 2)) * Math.Pow(ellipse.FirstRadius, 2));
					int x1 = ellipse.CenterX - offsetX;
					int x2 = ellipse.CenterX + offsetX;
                    int y2 = ellipse.CenterY + offsetY;

                    Console.SetCursorPosition(x1, y);
                    Console.Write(ellipse.Color);

                    Console.SetCursorPosition(x1, y2);
                    Console.Write(ellipse.Color);

                    Console.SetCursorPosition(x2, y);
                    Console.Write(ellipse.Color);

                    Console.SetCursorPosition(x2, y2);
                    Console.Write(ellipse.Color);

                    if (x1 != ellipse.CenterX && ellipse.BackgroundColor != ' ')
                    {
                        DrawLine(x1 + 1, y, x2 - 1, y, ellipse.BackgroundColor);
                        DrawLine(x1 + 1, y2, x2 - 1, y2, ellipse.BackgroundColor);
                    }
                }

				return true;
			}
			catch (Exception  e)
			{
				Console.WriteLine(e);
				return false;
			}
			
		}

		public bool DrawRectangle(int widthR, int heightR, char color = '#', char backgroundColor = ' ', string name = "None")
		{
			if (widthR * 2 > width || heightR * 2 > height) return false;

			Rectangle rectangle = new Rectangle(widthR, heightR);
			rectangle.CenterX = width / 2;
			rectangle.CenterY = height / 2;
			rectangle.Name = name;
			rectangle.Color = color;
			rectangle.BackgroundColor = backgroundColor;

			if (DrawRectangle(rectangle))
			{
				Figures.Add(rectangle);
				return true;
			}
			return false;
		}

		public bool DrawSquare(int lenght, char color = '#', char backgroundColor = ' ', string name = "None")
		{
			if (lenght * 2 > width || lenght * 2 > height) return false;

			Square square = new Square(lenght);
			square.CenterX = width / 2;
			square.CenterY = height / 2;
			square.Name = name;
			square.Color = color;
			square.BackgroundColor = backgroundColor;

			if (DrawRectangle(square))
			{
				Figures.Add(square);
				return true;
			}
			return false;
		}

		bool DrawRectangle(Rectangle rectangle)
		{
			try
			{
				int x1 = rectangle.CenterX - rectangle.Width / 2;
				int x2 = rectangle.CenterX + rectangle.Width / 2;
				int y1 = rectangle.CenterY - rectangle.Length / 2;
				int y2 = rectangle.CenterY + rectangle.Length / 2;

				DrawLine(x1, y1, x2, y1, rectangle.Color);
				DrawLine(x1, y2, x2, y2, rectangle.Color);
				DrawLine(x1, y1, x1, y2, rectangle.Color);
				DrawLine(x2, y1, x2, y2, rectangle.Color);
				if (rectangle.BackgroundColor != ' ')
				{

					for (int y = y1 + 1; y <= y2 - 1; y++)
					{
						DrawLine(x1 + 1, y, x2 - 1, y, rectangle.BackgroundColor);
					}
				}
				
				return true;
			}
			catch
			{
				return false;
			}
		}


		public bool DrawTriangle(int lenght, char color = '#', char backgroundColor = ' ', string name = "None")
		{
			if (lenght * 2 > width || lenght * 2 > height) return false;

			RightTriangle triangle = new RightTriangle(lenght);
			triangle.CenterX = width / 2;
			triangle.CenterY = height / 2;
			triangle.Name = name;
			triangle.Color = color;
			triangle.BackgroundColor = backgroundColor;

			if (DrawTriangle(triangle))
			{
				Figures.Add(triangle);
				return true;
			}
			return false;
		}

		public bool DrawTriangle(RightTriangle rightTriangle)
		{
			double h = Math.Sqrt(3) * rightTriangle.Length / 2;
			int x1 = rightTriangle.CenterX;
			int y1 = rightTriangle.CenterY - (int)Math.Round(h * 2 / 3);
			int x2 = rightTriangle.CenterX - rightTriangle.Length / 2;
			int x3 = rightTriangle.CenterX + rightTriangle.Length / 2;
			int y2_3 = rightTriangle.CenterY + (int)Math.Round(h / 3);

			DrawLine(x1, y1, x2, y2_3, rightTriangle.Color);
			DrawLine(x1, y1, x3, y2_3, rightTriangle.Color);
			DrawLine(x2, y2_3, x3, y2_3, rightTriangle.Color);

			if (rightTriangle.BackgroundColor != ' ')
			{

				int offsetXl = x2 - x1;
				int offsetYl = y2_3 - y1;
				double kl = offsetXl / (double)offsetYl;
				double bl = x1 - y1 * kl;

				int offsetXr = x3 - x1;
				int offsetYr = y2_3 - y1;
				double kr = offsetXr / (double)offsetYr;
				double br = x1 - y1 * kr;

				for (int y = y1 + 1; y <= y2_3 - 1; y++)
				{
					int xl = (int)Math.Round(kl * y + bl);
					int xr = (int)Math.Round(kr * y + br);
					for (int x = xl + 1; x <= xr - 1; x++)
					{
						Console.SetCursorPosition(x, y);
						Console.Write(rightTriangle.BackgroundColor);
					}
				}
			}

			return true;
		}
		bool DrawLine(int x1, int y1, int x2, int y2, char color)
		{
			if (y1 == y2)
			{
				if (x2 < x1) (x1, x2) = (x2, x1);
				for (int x = x1; x <= x2; x++)
				{
					Console.SetCursorPosition(x, y1);
					Console.Write(color);
				}
				return true;
			}

            if (y2 < y1) (x1, x2, y1, y2) = (x2, x1, y2, y1);
            int offsetX = x2 - x1;
            int offsetY = y2 - y1;
            double k = offsetX / (double)offsetY;
            double b = x1 - y1 * k;

			for (int y = y1; y <= y2; y++)
			{
				int x = (int)Math.Round(k * y + b);
                Console.SetCursorPosition(x, y);
                Console.Write(color);
            }
			return true;
		}
		public bool ReDraw()
		{
			try
			{
				Clear(2, height);
				foreach (IFigure figure in Figures)
				{
					if (figure is Circle) DrawEllipse(figure as Circle);
					else if (figure is Ellipse) DrawEllipse(figure as Ellipse);
					else if (figure is Square) DrawRectangle(figure as Square);
					else if (figure is Rectangle) DrawRectangle(figure as Rectangle);
					else if (figure is RightTriangle) DrawTriangle(figure as RightTriangle);
					else continue;
				}
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
			
		}
		public bool UnDraw(int index)
		{
			try
			{
				Figures.RemoveAt(index);
				ReDraw();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool Fill(int index, char backgroundColor)
		{
			try
			{
				Figures[index].BackgroundColor = backgroundColor;
				ReDraw();
				return true;
			}
			catch
			{
				return false;
			}
			
		}
		public bool Move(int index, int offset, char direction)
		{
			try
			{
				if (direction == 'u') Figures[index].CenterY -= offset;
				else if (direction == 'd') Figures[index].CenterY += offset;
				else if (direction == 'l') Figures[index].CenterX -= offset;
				else if (direction == 'r') Figures[index].CenterX += offset;
				else return false;
				ReDraw();
				return true;
			}
			catch
			{
				return false;
			}

        }

        public void Clear(int start, int end)
        {
            for (int i = start; i < end; ++i)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r");
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }

		public List<IFigure> GetFigures()
		{
			List<IFigure> newList = new List<IFigure>();
            foreach (IFigure figure in Figures)
            {
				if (figure is Circle) newList.Add(new Circle(figure as Circle));
				else if (figure is Ellipse) newList.Add(new Ellipse(figure as Ellipse));
                else if (figure is Square) newList.Add(new Square(figure as Square));
                else if (figure is Rectangle) newList.Add(new Rectangle(figure as Rectangle));
                else if (figure is RightTriangle) newList.Add(new RightTriangle(figure as RightTriangle));
                else continue;
            }
            return newList;
		}


    }
}
