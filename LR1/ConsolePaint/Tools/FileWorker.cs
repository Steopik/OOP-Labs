using ConsolePaint.Figures;


namespace ConsolePaint.Tools
{
	class FileWorker
	{
		

		string FileName;

		public FileWorker(string fileName)
		{
			FileName = fileName;

		}

		public bool Write(List<IFigure> figures)
		{
			try
			{
				string text = "";
				for (int i = 0; i < figures.Count; i ++)
				{
					IFigure figure = figures[i];

					string subText = "{\n";

					if (figure is Circle)
					{
						subText += $"Type: {"Circle"}\n";
						subText += $"Radius: {(figure as Circle).FirstRadius}\n";
					}
					else if (figure is Ellipse)
					{
						subText += $"Type: {"Ellipse"}\n";
						subText += $"FirstRadius: {(figure as Ellipse).FirstRadius}\n";
						subText += $"SecondRadius: {(figure as Ellipse).SecondRadius}\n";
					}
					else if (figure is Square)
					{
						subText += $"Type: {"Square"}\n";
						subText += $"Length: {(figure as Square).Length}\n";
					}
					else if (figure is Rectangle)
					{
						subText += $"Type: {"Rectangle"}\n";
						subText += $"Width: {(figure as Rectangle).Width}\n";
						subText += $"Length: {(figure as Rectangle).Length}\n";
					}
					else if (figure is RightTriangle)
					{
						subText += $"Type: {"RightTriangle"}\n";
						subText += $"Length: {(figure as RightTriangle).Length}\n";
					}
					else continue;
					subText += $"Name: {figure.Name}\n";
					subText += $"Color: {figure.Color}\n";
					subText += $"BackgroundColor: {figure.BackgroundColor}\n";
					subText += $"CenterX: {figure.CenterX}\n";
					subText += $"CenterY: {figure.CenterY}\n";
					subText += i==figures.Count - 1? "}" : "}\n";
					text += subText;
				}
				File.WriteAllText(FileName, text);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public List<IFigure> Read()
		{
			try
			{
				List<IFigure> list = new List<IFigure>();
				string fileText = File.ReadAllText(FileName);
				List<string> objectsList = fileText.Split("}\n").ToList();

				for (int i = 0; i < objectsList.Count; ++i)
				{
					string block = objectsList[i];
					block = block.TrimStart('{');
					block = block.TrimStart('\n');
					List<string> blocks = block.Split("\n").ToList();
					try
					{
						if (blocks[0].Split(": ")[1] == "Circle")
						{
							int radius = int.Parse(blocks[1].Split("Radius: ")[1]);
							char color = blocks[3].Split("Color: ")[1][0];
							char backgroundColor = blocks[4].Split("BackgroundColor: ")[1][0];
							int centerX = int.Parse(blocks[5].Split("CenterX: ")[1]);
							int centerY = int.Parse(blocks[6].Split("CenterY: ")[1]);
							string name = blocks[2].Split("Name: ")[1];

                            Circle temp = new Circle(radius, color, backgroundColor)
							{
								CenterX = centerX
								,
								CenterY = centerY
								,
								Name = name
							};
							list.Add(temp);
						}

						if (blocks[0].Split(": ")[1] == "Ellipse")
						{
                            int firstRadius = int.Parse(blocks[1].Split("FirstRadius: ")[1]);
							int secondRadius = int.Parse(blocks[2].Split("SecondRadius: ")[1]);
                            char color = blocks[4].Split("Color: ")[1][0];
                            char backgroundColor = blocks[5].Split("BackgroundColor: ")[1][0];
                            int centerX = int.Parse(blocks[6].Split("CenterX: ")[1]);
                            int centerY = int.Parse(blocks[7].Split("CenterY: ")[1]);
                            string name = blocks[3].Split("Name: ")[1];

                            Ellipse temp = new Ellipse(firstRadius , secondRadius, color, backgroundColor)
							{
								CenterX = centerX
								,
								CenterY = centerY
								,
								Name = name
							};
							list.Add(temp);
						}

						if (blocks[0].Split(": ")[1] == "Square")
						{
							List<string> a = blocks[1].Split("Length: ").ToList();
                            int length = int.Parse(blocks[1].Split("Length: ")[1]);
                            char color = blocks[3].Split("Color: ")[1][0];
                            char backgroundColor = blocks[4].Split("BackgroundColor: ")[1][0];
                            int centerX = int.Parse(blocks[5].Split("CenterX: ")[1]);
                            int centerY = int.Parse(blocks[6].Split("CenterY: ")[1]);
                            string name = blocks[2].Split("Name: ")[1];

                            Square temp = new Square(length, color, backgroundColor)
							{
								CenterX = centerX
								,
								CenterY = centerY
								,
								Name = name
							};
							list.Add(temp);
						}

						if (blocks[0].Split(": ")[1] == "Rectangle")
						{
							int width = int.Parse(blocks[1].Split("Width: ")[1]);
							int length = int.Parse(blocks[2].Split("Length: ")[1]);
							char color = blocks[4].Split("Color: ")[1][0];
							char backgroundColor = blocks[5].Split("BackgroundColor: ")[1][0];
							int centerX = int.Parse(blocks[6].Split("CenterX: ")[1]);
							int centerY = int.Parse(blocks[7].Split("CenterY: ")[1]);
							string name = blocks[3].Split("Name: ")[1];

							Rectangle temp = new Rectangle(width, length, color, backgroundColor)
							{
								CenterX = centerX
								,
								CenterY = centerY
								,
								Name = name
							};
							list.Add(temp);
						}

						if (blocks[0].Split(": ")[1] == "RightTriangle")
						{
                            int length = int.Parse(blocks[1].Split("Length: ")[1]);
                            char color = blocks[3].Split("Color: ")[1][0];
                            char backgroundColor = blocks[4].Split("BackgroundColor: ")[1][0];
                            int centerX = int.Parse(blocks[5].Split("CenterX: ")[1]);
                            int centerY = int.Parse(blocks[6].Split("CenterY: ")[1]);
                            string name = blocks[2].Split("Name: ")[1];

                            RightTriangle temp = new RightTriangle(length, color, backgroundColor)
                            {
                                CenterX = centerX
                ,
                                CenterY = centerY
                ,
                                Name = name
                            };
                            list.Add(temp);
						}
					}
					catch
					{
						continue;
					}
					
				}


				return list;
			}
			catch
			{
				return null;
			}
		}
	}
}
