namespace Domain.Models;

public class Data
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

}