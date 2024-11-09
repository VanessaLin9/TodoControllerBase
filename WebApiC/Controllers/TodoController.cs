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

// 2. 使用 Controller base 來實作一個 PUT API /todos/{id} 加上 body 可以修改特定一個 todo 的內容

// 3. 使用 Controller base 來實作一個 DELETE API /todos/{id} 可以刪除特定一個 todo

// 4. 使用 Controller base 來實作一個 POST API /todos?title={title}&dueby={dueby}&iscomplete={iscomplete} 不透過 body, 反而透過 query 來建立一個 todo 內容

// 5. 使用 Controller base 來實作一個 GET API /todos/search?title={title} 可以取得包含查詢條件的的 title

}