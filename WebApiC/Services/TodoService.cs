using WebApiC.Models;

namespace WebApiC.Services;

public class TodoService
{
    private List<Todo> _sampleList =
    [
        new(1, "Talk With Ann", DateOnly.FromDateTime(DateTime.Now), true),
        new(2, "Buy Some Drink"),
        new(3, "Finish Homework", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
    ];


    public List<Todo> GetAllTodo()
    {
        return _sampleList;
    }

    public Todo? GetTodoById(int id)
    {
        return _sampleList.FirstOrDefault(x => x!.Id == id);
    }

    public List<Todo>? AddTodo(Todo todo)
    {
        var id = _sampleList.Max(x => x!.Id) + 1;
        _sampleList.Add(todo with{Id = id});
        return _sampleList;
    }

    public List<Todo>? PutTodo(int id, Todo todo)
    {
        var modifyTodo = _sampleList.FindIndex(x => x!.Id == id);
        if (modifyTodo == -1)
        {
            return null;
        }

        _sampleList[modifyTodo] = todo;
        return _sampleList;
    }

    public List<Todo> DeleteTodo(int id)
    {
        var enumerable = _sampleList.First(x => x.Id == id);

        _sampleList.Remove(enumerable);
        return _sampleList;
    }

    public List<Todo>? FilterTodo(string title)
    {
        var enumerable = _sampleList.Where(x => x.Title!.Contains(title, StringComparison.OrdinalIgnoreCase));
        return enumerable.ToList();
    }
}