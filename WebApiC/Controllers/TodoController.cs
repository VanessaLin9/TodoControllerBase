using Microsoft.AspNetCore.Mvc;
using WebApiC.Models;
using WebApiC.Services;

namespace WebApiC.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(TodoService todoService) : ControllerBase
{
}