namespace WebApiC.Models;

public class Todo()
{

    public int Id { get; set; }
    public string? Title { get; set; }
    public DateOnly? DueBy { get; set; }
    public bool IsComplete { get; set; }

    public static Todo CreatTodo(int id, string? title, DateOnly? date = null, bool complete = false)
    {
        return new Todo
        {
            Id = id,
            Title = title,
            DueBy = date,
            IsComplete = complete
        };
    }

}