using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_TaskFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = new List<string> { "Task 1", "Task 2", "Task 3" };
            return Ok(tasks);
        }
        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = $"Task {id}";
            return Ok(task);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTask([FromBody] string task)
        {
            return CreatedAtAction(nameof(GetTaskById), new { id = 4 }, task);
        }
        
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] string task)
        {
            return NoContent();
        }
        
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            return NoContent();
        }
    }
}
