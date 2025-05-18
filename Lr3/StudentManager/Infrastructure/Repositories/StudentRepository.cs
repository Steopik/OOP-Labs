using StudentManager.Domain.Entities;
using StudentManager.Application.Interfaces;
using System.Text.Json;

namespace StudentManager.Infrastructure.Repositories;

using System.Text.Json;
using StudentManager.Domain.Entities;

public class StudentRepository : IStudentRepository
{
    private readonly string _filePath = "../../../../students.json";

    public void Add(Student student)
    {
        var students = GetAll();
        students.Add(student);
        SaveAll(students);
    }

    public void Update(Student student)
    {
        var students = GetAll();
        var index = students.FindIndex(s => s.Id == student.Id);
        if (index >= 0)
        {
            students[index] = student;
            SaveAll(students);
        }
    }

    public Student? GetById(string id)
    {
        var students = GetAll();
        return students.Find(s => s.Id == id);
    }

    public List<Student> GetAll()
    {
        if (!File.Exists(_filePath))
            return new List<Student>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }

    private void SaveAll(List<Student> students)
    {
        var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}
