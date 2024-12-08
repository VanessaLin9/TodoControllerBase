using WebApiC.Models;

namespace WebApiC.Services;

public class TodoService
{
    private readonly List<Todo?> _sampleList =
    [
        new(1, "Talk With Ann", DateOnly.FromDateTime(DateTime.Now), true),
        new(2, "Buy Some Drink"),
        new(3, "Finish Homework", DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
        new(4, "Go To The Gym"),
    ];


    public List<Todo?> GetAllTodo()
    {
        return _sampleList;
    }

    public Todo? GetTodoById(int id)
    {
        return _sampleList.FirstOrDefault(x => x!.Id == id);
    }

    public Todo AddTodo(Todo todo)
    {
        var id = _sampleList.Max(x => x!.Id) + 1;
        var newTodo = todo with { Id = id };
        _sampleList.Add(newTodo);
        return newTodo;
    }

    public List<Todo?> UpdateTodoById(int id, Todo todo)
    {
        var index = _sampleList.FindIndex(x => x!.Id ==id);

        _sampleList[index] = todo with { Id = id };
        return _sampleList;
    }

    public List<Todo>? DeleteTodoById(int id)
    {
        _sampleList.Remove(_sampleList.FirstOrDefault(x => x!.Id == id));
        return _sampleList!;
    }

    public Todo AddTodoByQuery(Todo todo)
    {
        return AddTodo(todo);
    }

    public List<Todo?> SearchTodoByTitle(string title)
    {
        return _sampleList.Where(x => x!.Title!.Contains(title, StringComparison.OrdinalIgnoreCase))!.ToList();
    }
}