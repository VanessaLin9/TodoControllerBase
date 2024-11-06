using Microsoft.AspNetCore.Mvc;
using WebApiC.Models;
using WebApiC.Services;

namespace WebApiC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(TodoService todoService) : ControllerBase
{
    [HttpGet]
    public List<Todo> GetTodos()
    {
        return todoService.ReturnTodos();
    }

    [HttpGet("{id}")]
    public Todo Get(int id)
    {
        return todoService.GetTodoById(id);
    }
    
    [HttpPost]
    public Todo Post([FromBody] RequestTodo todo)
    {
        return todoService.AddTodoItem(todo.Title, todo.IsComplete);
    }
    
    [HttpPut("{id}")]
    public Todo Put(int id, [FromBody] RequestTodo todo)
    {
        return todoService.UpdateTodoItem(id, todo.Title, todo.IsComplete);
    }
}