using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> findAll()
        {
            List<TaskModel> task = await _taskRepository.findAllTasks();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> findById(int id)
        {
            TaskModel task = await _taskRepository.findById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> createTask([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.createTask(taskModel);
            return Ok(task);
        }
    }
}
