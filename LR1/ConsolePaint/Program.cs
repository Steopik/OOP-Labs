using ConsolePaint;
using ConsolePaint.Figures;
using ConsolePaint.Tools;

public class Program
{
	static List<char> escapeCharacters = new List<char>
	{
		'\'',
		'"', 
		'\\',
		'\0',
		'\a',
		'\b',
		'\f',
		'\n',
		'\r',
		'\t',
		'\v' 
	};

	static int WIDTH = 212;
	static int HEIGHT = 50;
	static int FigursCount = 0;
	static Drawer drawer = new Drawer(WIDTH, HEIGHT);
	static ChangeAction changeAction = new ChangeAction();
	public static void Main(string[] args)
	{
		while (true)
		{
			drawer.Clear(0, 2);
			Console.SetCursorPosition(0, 1);
			Console.Write("List of commands: Draw(/dr); OpenFile(/of); SaveFile(/sf); MoveFigure(/mv); DelFigure(/d); Fill(/f); UndoAction(/u); RedoAction(/r);");
			Console.SetCursorPosition(0, 0);
			Console.Write("Enter command: ");

			string command = Console.ReadLine();
			switch (command)
			{
				case ("/dr"):
					if (Draw()) changeAction.Add(drawer.GetFigures());					
					break;

				case ("/of"):
					Open();
					break;

				case ("/sf"):
					WriteToFile();
					break;

				case ("/mv"):
					if (Move()) changeAction.Add(drawer.GetFigures());
                    break;

				case ("/d"):
                    int? index = SelectFigure();
                    if (index is not null)
                    {
                        drawer.Clear(0, 1);
                        Console.SetCursorPosition(0, 0);
						drawer.UnDraw(index ?? 0);
                        changeAction.Add(drawer.GetFigures());
                    }
                    break;

				case ("/f"):
					index = SelectFigure();
					if (index is not null)
					{
						drawer.Clear(0, 1);
						Console.SetCursorPosition(0, 0);
						char? backColor = ReceiveChar("Enret color to fill: ");
						if (backColor is not null)
						{
							drawer.Fill(index?? 0, backColor?? ' ');
                            changeAction.Add(drawer.GetFigures());
                        }
					} 
					break;

				case ("/u"):

					try
					{
						List<IFigure> figures = changeAction.Back();
						drawer = new Drawer(WIDTH, HEIGHT, figures);
						drawer.ReDraw();
                    }
					catch {}
                    break;

				case ("/r"):
                    try
                    {
                        List<IFigure> figures = changeAction.Forward();
                        drawer = new Drawer(WIDTH, HEIGHT, figures);
                        drawer.ReDraw();
                    }
                    catch { }
                    break;

				default:
					drawer.Clear(0, 2);
					break;
			}



		}
	}

	static bool Open()
	{
		try
		{
			if (drawer.GetFigures().Count > 0)
			{
                drawer.Clear(0, 2);
				Console.SetCursorPosition(0, 0);
				string? ans = "";
				while (ans != "yes" && ans != "no")
				{
                    ans = ReceiveString("Do you want to save the changes?(yes/no/(/q)): ");
                    if (ans is null) return false;
					if (ans == "yes")
					{
						WriteToFile();
						break;
					}
					else if (ans == "no") break;
                }

            }
			changeAction = new ChangeAction();
			drawer.Clear(0, 2);
			string? filepath = ReceiveString("Enter path to file to read: ");
			if (filepath is null) return false;

			FileWorker fileWorker = new FileWorker(filepath);
			List<IFigure> figures = fileWorker.Read();
			if (figures is null) return false;
			drawer = new Drawer(WIDTH, HEIGHT, figures);
			return drawer.ReDraw();
		}
		catch
		{
			return false;
		}
	}

	static bool WriteToFile()
	{
        try
        {
            drawer.Clear(0, 2);
            string? filepath = ReceiveString("Enter path to file to write: ");
            if (filepath is null) return false;

            FileWorker fileWorker = new FileWorker(filepath);
			return fileWorker.Write(drawer.GetFigures());
        }
        catch
        {
            return false;
        }
    }


    static bool Move()
    {
        try
        {
            int? index = SelectFigure();
            if (index is not null)
            {
                drawer.Clear(0, 1);
                Console.SetCursorPosition(0, 0);
				char? direction = null;
				while (direction is null)
				{
					direction = ReceiveChar("Enret Direction: ");
					if (direction is null) return false;
					if (direction != 'u' && direction != 'd' && direction != 'l' && direction != 'r') direction = null;

				}

				int? offset = ReceiveInt("Enter offset: ");

				return drawer.Move(index ?? 0, offset ?? 0, direction ?? 'u');

            }
			return false;
        }
        catch
        {
            return false;
        }
    }

    static bool Draw()
	{
		try
		{
			drawer.Clear(0, 2);
			Console.SetCursorPosition(0, 1);
			Console.Write("List of figures: Ellipse(/e); Circle(/c); Rectangle(/r); Square(/s); RightTriangle(/rt); Quit(/q)");
			Console.SetCursorPosition(0, 0);
			Console.Write("Enter command: ");

			while (true)
			{
				string command = Console.ReadLine();

				switch (command)
				{
					case "/e":
						{
							int? firstRadius = ReceiveInt("Enter firstRadius: ");
							if (firstRadius is null) return false;
							int? secondRadius = ReceiveInt("Enter secondRadius: ");
							if (secondRadius is null) return false;

							char? color = ReceiveChar("Enter color: ");
							if (color is null) return false;
							char? backColor = ReceiveChar("Enter backgroundColor: ");
							if (backColor is null) return false;

							string? name = ReceiveString("Enter name: ");

							return drawer.DrawEllipse(firstRadius ?? 1, secondRadius ?? 1, color ?? '#', backColor ?? ' ', name);
						}

					case "/c":
						{
							int? radius = ReceiveInt("Enter Radius: ");
							if (radius is null) return false;
							
							char? color = ReceiveChar("Enter color: ");
							if (color is null) return false;
							char? backColor = ReceiveChar("Enter backgroundColor: ");
							if (backColor is null) return false;

							string? name = ReceiveString("Enter name: ");

							return drawer.DrawCircle(radius ?? 1, color ?? '#', backColor ?? ' ', name);
						}

					case "/r":
						{
							int? width = ReceiveInt("Enter width: ");
							if (width is null) return false;
							int? lenght = ReceiveInt("Enter lenght: ");
							if (lenght is null) return false;

							char? color = ReceiveChar("Enter color: ");
							if (color is null) return false;
							char? backColor = ReceiveChar("Enter backgroundColor: ");
							if (backColor is null) return false;

							string? name = ReceiveString("Enter name: ");

							return drawer.DrawRectangle(width ?? 1, lenght ?? 1, color ?? '#', backColor ?? ' ', name);
						}

					case "/s":
						{
							int? lenght = ReceiveInt("Enter lenght: ");
							if (lenght is null) return false;

							char? color = ReceiveChar("Enter color: ");
							if (color is null) return false;
							char? backColor = ReceiveChar("Enter backgroundColor: ");
							if (backColor is null) return false;

							string? name = ReceiveString("Enter name: ");

							return drawer.DrawSquare(lenght ?? 1, color ?? '#', backColor ?? ' ', name);
						}

					case "/rt":
						{
							int? lenght = ReceiveInt("Enter lenght: ");
							if (lenght is null) return false;

							char? color = ReceiveChar("Enter color: ");
							if (color is null) return false;
							char? backColor = ReceiveChar("Enter backgroundColor: ");
							if (backColor is null) return false;

							string? name = ReceiveString("Enter name: ");

							return drawer.DrawTriangle(lenght ?? 1, color ?? '#', backColor ?? ' ', name);
						}

					case "/q":
						return false;

					default:
						drawer.Clear(0, 2);
						Console.SetCursorPosition(0, 1);
						Console.Write("List of figures: Ellipse(/e); Circle(/c); Rectangle(/r); Square(/s); RightTriangle(/rt); Quit(/q)");
						Console.SetCursorPosition(0, 0);
						Console.Write("Enter command: ");
						break;
				}
			}
		}
		catch
		{
			return false;
		}
	} 

	//static void SetInitialConsoleSize(int width, int height)
	//{
	//	try
	//	{
	//		Console.SetWindowSize(width, height);
	//		Console.SetBufferSize(width, height); 
	//	}
	//	catch (Exception e)
	//	{
	//	}
	//}

	static int? ReceiveInt(string messagge)
	{
		while (true)
		{
			drawer.Clear(0, 1);
			Console.SetCursorPosition(0, 0);
			Console.Write(messagge);
			try
			{
				string input = Console.ReadLine();
				if (input == "/q") return null;

				int enter = int.Parse(input);
				return enter;
			}
			catch
			{
				continue;
			}
		}
	}

	static char? ReceiveChar(string messagge)
	{
		while (true)
		{
			try
			{
				bool hasEscapeCharacters = false;

				drawer.Clear(0, 1);
				Console.SetCursorPosition(0, 0);
				Console.Write(messagge);
				string input = Console.ReadLine();
				if (input == "/q") return null;

				foreach (char ch in escapeCharacters)
				{
					if (input.Contains(ch))
					{
						hasEscapeCharacters = true;
						break;
					}
				}
				if (hasEscapeCharacters) continue;

				char enter = char.Parse(input);
				return enter;
			}
			catch
			{
				continue;
			}
		}
	}

	static string? ReceiveString(string messagge)
	{
		while (true)
		{
			try
			{
				bool hasEscapeCharacters = false;
				drawer.Clear(0, 1);
				Console.SetCursorPosition(0, 0);
				Console.Write(messagge);

				string input = Console.ReadLine();
				if (input == "/q") return null;

				foreach (char ch in escapeCharacters)
				{
					if (input.Contains(ch))
					{
						hasEscapeCharacters = true;
						break;
					}
				}
				if (hasEscapeCharacters) continue;

				
				return input;
			}
			catch
			{
				continue;
			}
		}
	}


	static int? SelectFigure()
	{
		drawer.Clear(0, 2);
		Console.SetCursorPosition(0, 1);
		List<IFigure> figures = drawer.GetFigures(); 
		for (int i = 0; i < figures.Count; i++)
		{
			List<string> type = figures[i].GetType().ToString().Split('.').ToList();

			Console.Write($"[{i}|{type[type.Count - 1]}|{figures[i].Name}] ");
		}
		int? index = null;
		while (((index?? -1) < 0) || ((index ?? -1) > figures.Count - 1))
		{
			index = ReceiveInt("Enter index of Figure: ");
			if ((index ?? -1) >= 0 && (index ?? -1) < figures.Count) return index;
			if (index is null) return null;
        }
		return null;
		

	}
}
