using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;
using TaskSystem.Services.Task;

namespace TaskSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> findAll()
        {
            List<TaskModel> task = await _taskService.GetAll();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> findById(int id)
        {
            TaskModel task = await _taskService.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> createTask([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskService.Create(taskModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> updateTask([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskService.Update(taskModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> deleteTask(int id)
        {
            bool deleted = await _taskService.Delete(id);
            return Ok(deleted);
        }
    }
}
