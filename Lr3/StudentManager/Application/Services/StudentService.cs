using StudentManager.Application.Interfaces;
using StudentManager.Application.Factories;
using StudentManager.Domain.DTOs;

namespace StudentManager.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IQuoteService _quoteService;

    public StudentService(IStudentRepository repository, IQuoteService quoteService)
    {
        _repository = repository;
        _quoteService = quoteService;
    }

    public string AddStudent(StudentDTO dto)
    {
        var student = StudentFactory.Create(dto); // создает новый Student с новым Id
        _repository.Add(student);
        return _quoteService.GetMotivationalQuote();
    }

    public bool EditStudent(string id, StudentDTO dto)
    {
        var existingStudent = _repository.GetById(id);
        if (existingStudent == null)
            return false;

        // Обновляем данные студента
        existingStudent.Update(dto.Name, dto.Mark);
        _repository.Update(existingStudent);
        return true;
    }

    public List<StudentDTO> GetAllStudents()
    {
        var students = _repository.GetAll();
        return students.Select(s => new StudentDTO
        {
            Id = s.Id,
            Name = s.Name,
            Mark = s.Mark
        }).ToList();
    }
}
