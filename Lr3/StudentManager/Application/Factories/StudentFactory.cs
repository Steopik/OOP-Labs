using StudentManager.Domain.DTOs;
using StudentManager.Domain.Entities;

namespace StudentManager.Application.Factories;

public static class StudentFactory
{
    public static Student Create(StudentDTO dto)
    {
        return Student.Create(dto.Name, dto.Mark);
    }
}
