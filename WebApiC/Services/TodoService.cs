using WebApiC.Models;

namespace WebApiC.Services;

public class TodoService
{
    private List<Todo?> _sampleList =
    [
        new(1, "Talk With Ann", DateOnly.FromDateTime(DateTime.Now), true),
        new(2, "Buy Some Drink"),
        new(3, "Finish Homework", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
    ];


    public List<Todo?> GetAllTodo()
    {
        return _sampleList;
    }

    public Todo? GetTodoById(int id)
    {
        return _sampleList.FirstOrDefault(x => x!.Id == id);
    }
}