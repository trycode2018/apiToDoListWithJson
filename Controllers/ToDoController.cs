using ApiToDoJson.Interfaces;
using ApiToDoJson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiToDoJson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;
        public ToDoController(IToDoService service)=>_service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = _service.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _service.GetByIdAsync(id);
            return todo!=null ? Ok(todo) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ToDoItem item)
        {
            await _service.AddAsync(item);
            return Ok("Item adicionado com sucesso");
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id,ToDoItem item)
        {
            await _service.UpdateAsync(id, item);
            return Ok("Item atualizado com sucesso!");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Item removido com sucesso");
        }
    }
}
