using StudentManager.Application.Services;

namespace Presentation.Commands;

public class ViewStudentsCommandHandler : ICommandHandler
{
    private readonly StudentService _studentService;

    public ViewStudentsCommandHandler(StudentService studentService)
    {
        _studentService = studentService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Список студентов ===");

        var students = _studentService.GetAllStudents();

        foreach (var s in students)
        {
            Console.WriteLine($"ID: {s.Id}, Имя: {s.Name}, Оценка: {s.Mark}");
        }

        Console.WriteLine("\nНажмите Enter для возврата...");
        Console.ReadLine();
    }
}
