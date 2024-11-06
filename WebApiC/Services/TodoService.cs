using System.Diagnostics;
using WebApiC.Controllers;
using WebApiC.Models;

namespace WebApiC.Services;

public class TodoService
{
    private List<Todo> _sampleTodo =
    [
        Todo.CreatTodo(0, "Got To Work", false),
        Todo.CreatTodo(1, "Go to Sleep", false)
    ];

    public List<Todo> ReturnTodos()
    {
        return _sampleTodo;
    }

    public Todo GetTodoById(int id)
    {
        return _sampleTodo.FirstOrDefault(x => x.Id == id);
    }

    public Todo AddTodoItem(string title, bool complete)
    {
        var id = Math.Max(_sampleTodo.Max(x => x.Id), 0) + 1;
        var creatTodo = Todo.CreatTodo(id, title,complete);
        _sampleTodo.Add(creatTodo);
        return creatTodo;
    }

    public Todo UpdateTodoItem(int id, string todoTitle, bool todoIsComplete)
    {
        var todo = _sampleTodo.FirstOrDefault(x => x.Id == id);
        if (todo == null)
        {
            return null;
        }

        todo.Title = todoTitle;
        todo.IsComplete = todoIsComplete;
        return todo;
    }
}