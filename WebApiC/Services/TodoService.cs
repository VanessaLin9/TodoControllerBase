using System.Diagnostics;
using WebApiC.Controllers;
using WebApiC.Models;

namespace WebApiC.Services;

public class TodoService
{
    private List<Todo> _sampleList =
    [
        Todo.CreatTodo(1, "Talk With Ann", DateOnly.FromDateTime(DateTime.Now), true),
        Todo.CreatTodo(2, "Buy Some Drink"),
        Todo.CreatTodo(3, "Finish Homework", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
    ];


    public List<Todo> GetAllTodo()
    {
        return _sampleList;
    }
}