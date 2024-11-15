using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApiC.Models;
using WebApiC.Services;

namespace WebApiC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(TodoService todoService) : ControllerBase
{

    [HttpGet]
    [Route("/")]
    public List<Todo> GetAllTodos()
    {
        return todoService.GetAllTodo();
    }


// 1. 使用 Controller base 來實作一個 POST API /todos 透過 body 可以建立一個 todo

    // [HttpPost("/")]
    // public Todo PostTodo(Todo todo)
    // {
    //     return todoService.AddTodo(todo);
    // }

    [HttpGet("/{id}")]
    public Todo? GetTodoById(int id)
    {
        var todoById = todoService.GetTodoById(id);

        return todoById;
        Response.StatusCode = (int) HttpStatusCode.NotFound;
        return null;
    }
    
// 2. 使用 Controller base 來實作一個 PUT API /todos/{id} 加上 body 可以修改特定一個 todo 的內容

    [HttpPut("/{id}")]
    public List<Todo> PutTodo(int id, Todo todo)
    {
        return todoService.UpdateTodo(id, todo);
    }

// 3. 使用 Controller base 來實作一個 DELETE API /todos/{id} 可以刪除特定一個 todo
    [HttpDelete("/{id}")]
    public List<Todo> DeleteTodo(int id)
    {
        return todoService.DeleteTodo(id);
    }

// 4. 使用 Controller base 來實作一個 POST API /todos?title={title}&dueby={dueby}&iscomplete={iscomplete} 不透過 body, 反而透過 query 來建立一個 todo 內容

    [HttpPost("/")]
    public Todo PostTodoByQuery(string title, string? dueBy, bool? isComplete = false)
    {
        return todoService.AddTodo(new Todo
        {
            Title = title,
            DueBy = DateOnly.ParseExact(dueBy, "yyyy-mm-dd"),
            IsComplete = isComplete?? false
        });
    }
// 5. 使用 Controller base 來實作一個 GET API /todos/search?title={title} 可以取得包含查詢條件的的 title
    [HttpGet("/search")]
    public List<Todo> FilerTodos(string title)
    {
        return string.IsNullOrEmpty(title) ? todoService.GetAllTodo() : todoService.GetFilteredTodo(title);
    }

    [HttpGet("/searchMe")]
    public List<Todo> GetTagTodos(string who)
    {
        return todoService.GetTagTodo(who);
    }

}
