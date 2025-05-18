using StudentManager.Domain.Entities;

namespace StudentManager.Application.Interfaces;

public interface IStudentRepository
{
    void Add(Student student);
    void Update(Student student); 
    Student? GetById(string id);
    List<Student> GetAll();
}
