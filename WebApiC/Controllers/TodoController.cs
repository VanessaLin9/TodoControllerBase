using Microsoft.AspNetCore.Mvc;

namespace WebApiC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController: ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }
}