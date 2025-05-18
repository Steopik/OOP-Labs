using StudentManager.Application.Interfaces;

namespace StudentManager.Application.Commands;

public class ViewStudentsCommand : IStudentCommand
{
    private readonly IStudentService _service;

    public ViewStudentsCommand(IStudentService service)
    {
        _service = service;
    }

    public void Execute()
    {
        var students = _service.GetAllStudents();
        if (students.Count == 0)
        {
            Console.WriteLine("Список студентов пуст.");
            return;
        }

        Console.WriteLine("Список студентов:");
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{students[i].Id}: {students[i].Name} — {students[i].Mark}");
        }
    }
}
