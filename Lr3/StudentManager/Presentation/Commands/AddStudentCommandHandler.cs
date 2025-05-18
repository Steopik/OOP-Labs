using StudentManager.Domain.DTOs;
using StudentManager.Application.Services;

namespace Presentation.Commands;

public class AddStudentCommandHandler : ICommandHandler
{
    private readonly StudentService _studentService;

    public AddStudentCommandHandler(StudentService studentService)
    {
        _studentService = studentService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Добавление студента ===");
        Console.Write("Введите имя: ");
        var name = Console.ReadLine();

        Console.Write("Введите оценку (0–100): ");
        var gradeInput = Console.ReadLine();

        if (!int.TryParse(gradeInput, out int mark))
        {
            Console.WriteLine("Неверный формат оценки.");
            Console.ReadLine();
            return;
        }

        var dto = new StudentDTO { Name = name!, Mark = mark };
        var result = _studentService.AddStudent(dto);

        Console.WriteLine("Студент добавлен.");
        Console.WriteLine($"Цитата: {result}");
        Console.ReadLine();
    }
}
