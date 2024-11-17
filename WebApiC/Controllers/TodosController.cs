using Microsoft.AspNetCore.Mvc;
using WebApiC.Models;
using WebApiC.Services;

namespace WebApiC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController(TodoService todoService) : ControllerBase
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
        if (todoById is null)
        { 
            HttpContext.Response.StatusCode = 404;
        }

        return todoById;
    }

// 6. 使用 Controller base 來實作一個 POST API /todos 透過 body 可以建立一個 todo

    [HttpPost("/")]
    public Todo AddTodo(Todo todo)
    {
        return todoService.AddTodo(todo);
    }

// 7. 使用 Controller base 來實作一個 PUT API /todos/{id} 加上 body 可以修改特定一個 todo 的內容

    [HttpPut("/{id:int}")]
public List<Todo>? UpdateTodoById(int id, Todo todo)
{
    if (!CheckTodoExist(id)) return todoService.UpdateTodoById(id, todo)!;
    HttpContext.Response.StatusCode = 404;
    return null;

}


// 8. 使用 Controller base 來實作一個 DELETE API /todos/{id} 可以刪除特定一個 todo

    [HttpDelete("/{id:int}")]
public List<Todo>? DeleteTodoById(int id)
{
    if (!CheckTodoExist(id)) return todoService.DeleteTodoById(id);
    HttpContext.Response.StatusCode = 404;
    return null;
}


// 9. 使用 Controller base 來實作一個 POST API /todos?title={title}&dueby={dueby}&iscomplete={iscomplete} 不透過 body, 反而透過 query 來建立一個 todo 內容
// [HttpPost("/")]
// public Todo AddTodoByQuery(string title, DateOnly? dueby = null, bool iscomplete = false)
// {
//     var todo = new Todo(0, title, dueby, iscomplete);
//     return todoService.AddTodoByQuery(todo);
// }
    

// 10. 使用 Controller base 來實作一個 GET API /todos/search?title={title} 可以取得包含查詢條件的的 titles
    [HttpGet("/search")]
    public List<Todo>? SearchTodoByTitle(string title)
    {
        List<Todo>? searchTodoByTitle = todoService.SearchTodoByTitle(title)!;
        if (searchTodoByTitle.Count == 0)
        {
            HttpContext.Response.StatusCode = 204;
            return null;
        }
        return searchTodoByTitle;
    }
    private bool CheckTodoExist(int id)
    {
        var todoById = todoService.GetTodoById(id);
        return todoById is null;
    }
}