using StudentManager.Infrastructure.Adapters;

using StudentManager.Application.Commands;
using StudentManager.Application.Services;
using StudentManager.Infrastructure.Repositories;

class Program
{
    static void Main()
    {
        var repository = new StudentRepository();
        var quoteService = new QuoteApiAdapter(); 
        var studentService = new StudentService(repository, quoteService);

        var addCommand = new AddStudentCommand(studentService);
        var editCommand = new EditStudentCommand(studentService);
        var viewCommand = new ViewStudentsCommand(studentService);

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1 - Добавить студента");
            Console.WriteLine("2 - Редактировать студента");
            Console.WriteLine("3 - Просмотреть всех студентов");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите действие: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    addCommand.Execute();
                    break;
                case "2":
                    editCommand.Execute();
                    break;
                case "3":
                    viewCommand.Execute();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
        }
    }
}
