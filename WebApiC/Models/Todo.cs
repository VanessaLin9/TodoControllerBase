namespace WebApiC.Models;

public class Todo()
{

    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }

    public static Todo CreatTodo(int i, string gotToWork, bool b)
    {
        return new Todo
        {
            Id = i,
            Title = gotToWork,
            IsComplete = b
        };
    }
}