using Domain;
using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs.Requests;
using TodoList.DTOs.Results;
using TodoList.Mappers;

namespace TodoList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(Endpoints context) : ControllerBase
{
    private readonly Endpoints _context = context;

    [HttpPost("CreateNewTodo")]
    public async Task<ActionResult<TodoResult>> CreateNewTodo(TodoRequest todo)
    {
        var entity = todo.FromRequest();
        await _context.Todos.CreateAsync(entity);
        var resultEntity = entity.ToResult();
        return CreatedAtRoute(nameof(GetTodoById), new { resultEntity.Id }, resultEntity);
    }

    [HttpGet("{id}", Name = "GetTodoById")]
    public async Task<ActionResult<TodoResult>> GetTodoById(int id)
    {
        var result = await _context.Todos.GetItemByIdAsync(id);
        return Ok(result!.ToResult());
    }

    [HttpPut("{id}", Name = "UpdateTodo")]
    public async Task<ActionResult<TodoResult>> UpdateTodo(int id, TodoRequest todo)
    {
        var entity = todo.FromRequest();
        var updatedEntity = await _context.Todos.UpdateAsync(entity, id);
        return Ok(updatedEntity.ToResult());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTodo(int id)
    {
        await _context.Todos.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("GetAllTodos")]
    public async Task<ActionResult<TodoResult>> GetAllTodos()
    {
        var result = await _context.Todos.GetAllAsync();
        return Ok(result.ToResults());
    }
}
