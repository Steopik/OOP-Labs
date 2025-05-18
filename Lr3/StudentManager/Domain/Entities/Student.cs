using System.Text.Json.Serialization;

namespace StudentManager.Domain.Entities;

public class Student
{
    public string Id { get; private set; }  
    public string Name { get; private set; }
    public int Mark { get; private set; }

    [JsonConstructor]
    public Student(string id, string name, int mark)
    {
        Id = id;
        Name = name;
        Mark = mark;
    }

    public static Student Create(string name, int mark)
    {
        return new Student(Guid.NewGuid().ToString(), name, mark);
    }

    public void Update(string name, int mark)
    {
        Name = name;
        Mark = mark;
    }
}