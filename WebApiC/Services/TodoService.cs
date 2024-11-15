using WebApiC.Models;

namespace WebApiC.Services;

public class TodoService
{
    private List<Todo> _sampleList =
    [
        Todo.CreatTodo(1, "Talk With Ann", DateOnly.FromDateTime(DateTime.Now), true),
        Todo.CreatTodo(2, "Buy Some Drink"),
        Todo.CreatTodo(3, "Finish Homework", DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
        Todo.CreatTodo(4, "vanessa's extension method")
    ];


    public List<Todo> GetAllTodo()
    {
        return _sampleList;
    }

    public Todo AddTodo(Todo todo)
    {
        var id = _sampleList.Count != 0 ? _sampleList.Max(x => x.Id) + 1: 1;
        var creatTodo = Todo.CreatTodo(id, todo.Title, todo.DueBy, todo.IsComplete);
        _sampleList.Add(creatTodo); 
        return creatTodo;
    }

    public List<Todo> UpdateTodo(int id, Todo todo)
    {
        var index = _sampleList.FirstOrDefault(x => x.Id == id);
        if (index == null)
        {
            return null!;
        }

        index.Title = todo.Title;
        index.DueBy = todo.DueBy;
        index.IsComplete = todo.IsComplete;
        return _sampleList;
    }

    public List<Todo> DeleteTodo(int id)
    {
        var todo = _sampleList.SingleOrDefault(x => x.Id == id);
        if (todo == null)
        {
            return [todo!];
        }

        _sampleList.Remove(todo); 
        return _sampleList;
    }

    public List<Todo> GetFilteredTodo(string title)
    {
        var selected = _sampleList.Where(x => x.Title!.Contains(title)).ToList();
        return selected.Count != 0 ? _sampleList : selected;
    }

    public List<Todo> GetTagTodo(string who)
    {
        return _sampleList.WhereTagMe(who).ToList();
    }

    public Todo GetTodoById(int id)
    {
        return _sampleList.FirstOrDefault(x=> x.Id == id)!;
    }
}

public static class VanessaExtension{
    public static IEnumerable<Todo> WhereTagMe(this IEnumerable<Todo> todoList, string person)
    {
        return todoList.Where(x => x.Title!.Contains(person)).ToList();
    }
}