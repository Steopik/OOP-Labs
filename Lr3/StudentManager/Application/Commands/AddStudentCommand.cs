using StudentManager.Application.Interfaces;
using StudentManager.Domain.DTOs;

namespace StudentManager.Application.Commands;

public class AddStudentCommand : IStudentCommand
{
    private readonly IStudentService _service;

    public AddStudentCommand(IStudentService service)
    {
        _service = service;
    }

    public void Execute()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Введите оценку студента (0–100): ");
        string gradeInput = Console.ReadLine() ?? "";
        if (!int.TryParse(gradeInput, out int mark) || mark < 0 || mark > 100)
        {
            Console.WriteLine("Ошибка: некорректная оценка.");
            return;
        }

        var dto = new StudentDTO { Name = name, Mark = mark };

        string quote = _service.AddStudent(dto);
        Console.WriteLine("Студент добавлен.");
        Console.WriteLine($"Мотивационная цитата: {quote}");
    }
}
