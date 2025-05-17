using System.Text.Json.Serialization;

namespace ConsolePaint.Figures
{
    public interface IFigure
    {
        char Color { get; set; }
        char BackgroundColor { get; set; }
        int CenterX { get; set; }
        int CenterY { get; set; }
        String? Name { get; set; }

    }
}
