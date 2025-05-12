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
            var list = new List<TaskModel> { new TaskModel{Id = 1, Name = "Manu", Description = "Task 1", Status = (TaskStatus)1, UserId = 1}};
            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(list);

            var result = await _service.GetAll();

            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
