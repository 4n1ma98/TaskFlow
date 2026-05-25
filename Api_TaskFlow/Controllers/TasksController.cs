using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Responses;

namespace Api_TaskFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService iTaskService;
        public TasksController(ITaskService taskService)
        {
            iTaskService = taskService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTasks()
        {
            GenericResult resultCallApi = await iTaskService.GetTasksAsync();
            return Ok(resultCallApi);
        }
        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            GenericResult resultCallApi = await iTaskService.GetTaskByIdAsync(id);
            return Ok(resultCallApi);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTask([FromBody] string task)
        {
            GenericResult resultCallApi = await iTaskService.CreateTaskAsync(task);
            return Ok(resultCallApi);
        }
        
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] string task)
        {
            GenericResult resultCallApi = await iTaskService.UpdateTaskAsync(id, task);
            return Ok(resultCallApi);
        }
        
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            GenericResult resultCallApi = await iTaskService.DeleteTaskAsync(id);
            return Ok(resultCallApi);
        }
    }
}
