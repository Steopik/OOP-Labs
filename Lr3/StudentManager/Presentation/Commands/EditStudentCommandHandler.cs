using StudentManager.Domain.DTOs;
using StudentManager.Application.Services;

namespace Presentation.Commands;

public class EditStudentCommandHandler : ICommandHandler
{
    private readonly StudentService _studentService;

    public EditStudentCommandHandler(StudentService studentService)
    {
        _studentService = studentService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Редактирование студента ===");
        Console.Write("Введите ID студента: ");
        var id = Console.ReadLine();

        Console.Write("Новое имя: ");
        var name = Console.ReadLine();

        Console.Write("Новая оценка: ");
        var gradeInput = Console.ReadLine();

        if (!int.TryParse(gradeInput, out int mark))
        {
            Console.WriteLine("Неверный формат оценки.");
            Console.ReadLine();
            return;
        }

        var dto = new StudentDTO { Id = id!, Name = name!, Mark = mark };

        var success = _studentService.EditStudent(id!, dto);

        Console.WriteLine(success ? "Студент обновлён." : "Студент не найден.");
        Console.ReadLine();
    }
}
