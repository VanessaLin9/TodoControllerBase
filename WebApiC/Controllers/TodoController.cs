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
    public List<Todo?> GetAllTodos()
    {
        return todoService.GetAllTodo();
    }

    [HttpGet("/{id:int}")]
    public Todo? GetTodoById(int id)
    {
        var todoById = todoService.GetTodoById(id);


        return todoById;
    }

// 6. 使用 Controller base 來實作一個 POST API /todos 透過 body 可以建立一個 todo
    [HttpPost("/")]
    public OkObjectResult AddTodo(Todo todo)
    {
        var todoList = todoService.AddTodo(todo);
        return Ok(todoList);
    }


// 7. 使用 Controller base 來實作一個 PUT API /todos/{id} 加上 body 可以修改特定一個 todo 的內容
    [HttpPut("/id:int")]
    public OkObjectResult PutTodo(int id, Todo todo)
    {
        var todos = todoService.PutTodo(id, todo);
        return new OkObjectResult(todos!.Count == 0?NotFound() : Ok(todos));
    }


// 8. 使用 Controller base 來實作一個 DELETE API /todos/{id} 可以刪除特定一個 todo
    [HttpDelete("/{id:int}")]
    public OkObjectResult DeleteTodo(int id)
    {
        var todos = todoService.DeleteTodo(id);
        return Ok(todos);
    }

// 9. 使用 Controller base 來實作一個 POST API /todos?title={title}&dueby={dueby}&iscomplete={iscomplete} 不透過 body, 反而透過 query 來建立一個 todo 內容
    [HttpPost("/")]
    public OkObjectResult AddTodoByQuery(string title, string? dueby , bool iscomplete)
    {
        var dateOnly = dueby is null ? DateOnly.ParseExact(dueby, "yyyy-MM-dd"): DateOnly.FromDateTime(DateTime.Now);
        var todo = new Todo(0, title, dateOnly, iscomplete);
        var addTodo = todoService.AddTodo(todo);
        return Ok(addTodo);
    } 

// 10. 使用 Controller base 來實作一個 GET API /todos/search?title={title} 可以取得包含查詢條件的的 titles
    [HttpGet("/search")]
    public OkObjectResult FilterTodo(string title)
    {
        var filterTodo = todoService.FilterTodo(title);
        return new OkObjectResult(filterTodo == null ? NotFound() : Ok(filterTodo));
    }
}