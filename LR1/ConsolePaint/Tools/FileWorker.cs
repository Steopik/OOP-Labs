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
                        subText += $"Lenght: {(figure as Square).Length}\n";
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
                            Circle temp = new Circle(radius: int.Parse(blocks[1].Split(": ")[1])
                                , color: blocks[3].Split(": ")[1][0]
                                , backgroundColor: blocks[4].Split(": ")[1][0]
                                )
                            {
                                CenterX = int.Parse(blocks[5].Split(": ")[1])
                                ,
                                CenterY = int.Parse(blocks[6].Split(": ")[1])
                                ,
                                Name = blocks[2].Split(": ")[1]
                            };
                            list.Add(temp);
                        }
                        if (blocks[0].Split(": ")[1] == "Ellipse")
                        {
                            Ellipse temp = new Ellipse(firstRadius: int.Parse(blocks[1].Split(": ")[1])
                                , secondRadius: int.Parse(blocks[1].Split(": ")[2])
                                , color: blocks[4].Split(": ")[1][0]
                                , backgroundColor: blocks[5].Split(": ")[1][0]
                                )
                            {
                                CenterX = int.Parse(blocks[6].Split(": ")[1])
                                ,
                                CenterY = int.Parse(blocks[7].Split(": ")[1])
                                ,
                                Name = blocks[3].Split(": ")[1]
                            };
                            list.Add(temp);
                        }
                        if (blocks[0].Split(": ")[1] == "Square")
                        {
                            Square temp = new Square(length: int.Parse(blocks[1].Split(": ")[1])
                                , color: blocks[3].Split(": ")[1][0]
                                , backgroundColor: blocks[4].Split(": ")[1][0]
                                )
                            {
                                CenterX = int.Parse(blocks[5].Split(": ")[1])
                                ,
                                CenterY = int.Parse(blocks[6].Split(": ")[1])
                                ,
                                Name = blocks[2].Split(": ")[1]
                            };
                            list.Add(temp);
                        }
                        if (blocks[0].Split(": ")[1] == "Rectangle")
                        {
                            Rectangle temp = new Rectangle(width: int.Parse(blocks[1].Split(": ")[1])
                                , length: int.Parse(blocks[2].Split(": ")[1])
                                , color: blocks[4].Split(": ")[1][0]
                                , backgroundColor: blocks[5].Split(": ")[1][0]
                                )
                            {
                                CenterX = int.Parse(blocks[6].Split(": ")[1])
                                ,
                                CenterY = int.Parse(blocks[7].Split(": ")[1])
                                ,
                                Name = blocks[2].Split(": ")[1]
                            };
                            list.Add(temp);
                        }
                        if (blocks[0].Split(": ")[1] == "RightTriangle")
                        {
                            RightTriangle temp = new RightTriangle(length: int.Parse(blocks[1].Split(": ")[1])
                                , color: blocks[3].Split(": ")[1][0]
                                , backgroundColor: blocks[4].Split(": ")[1][0]
                                )
                            {
                                CenterX = int.Parse(blocks[5].Split(": ")[1])
                                ,
                                CenterY = int.Parse(blocks[6].Split(": ")[1])
                                ,
                                Name = blocks[2].Split(": ")[1]
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
