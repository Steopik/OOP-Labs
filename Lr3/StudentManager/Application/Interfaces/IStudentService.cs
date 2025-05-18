using StudentManager.Domain.DTOs;

namespace StudentManager.Application.Interfaces;

public interface IStudentService
{
    string AddStudent(StudentDTO dto);
    bool EditStudent(string id, StudentDTO dto);
    List<StudentDTO> GetAllStudents();
}
