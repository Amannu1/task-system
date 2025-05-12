using Moq;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;
using TaskSystem.Services.Task;

namespace TaskSystemTest
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _repository;
        private readonly TaskService _service;

        public TaskServiceTests()
        {
            _repository = new Mock<ITaskRepository>();
            _service = new TaskService(_repository.Object);
        }

        [Fact]
        public async Task GetAllShouldReturnTaskList()
        {
            var list = new List<TaskModel> { new TaskModel{Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1}};
            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(list);

            var result = await _service.GetAll();

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetByIdShouldReturnExistingUser()
        {
            TaskModel task = new TaskModel { Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1 };
            _repository.Setup(repo => repo.GetById(task.Id)).ReturnsAsync(task);

            var result = await _service.GetById(task.Id);

            Assert.NotNull(result);
            Assert.Equal(task.Name, result.Name);
            Assert.Equal(task.Id, result.Id);
    
        }
    }
}
