using StudentManager.Domain.DTOs;
using StudentManager.Application.Interfaces;
using System.Windows.Input;

namespace StudentManager.Application.Commands;

public class EditStudentCommand : IStudentCommand
{
    private readonly IStudentService _studentService;

    public EditStudentCommand(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public void Execute()
    {
        Console.Write("Введите ID студента для редактирования: ");
        var id = Console.ReadLine();

        Console.Write("Введите новое имя: ");
        var name = Console.ReadLine();

        Console.Write("Введите новую оценку (mark): ");
        var markInput = Console.ReadLine();

        if (!int.TryParse(markInput, out int mark))
        {
            Console.WriteLine("Ошибка: оценка должна быть числом.");
            return;
        }

        var dto = new StudentDTO
        {
            Name = name ?? string.Empty,
            Mark = mark
        };

        var success = _studentService.EditStudent(id!, dto);

        if (success)
            Console.WriteLine("Студент успешно обновлен.");
        else
            Console.WriteLine("Студент с таким ID не найден.");
    }
}
