namespace StudentManager.Domain.DTOs;

public class StudentDTO
{
    public string? Id { get; set; }   
    public string Name { get; set; } = string.Empty;
    public int Mark { get; set; }
}
