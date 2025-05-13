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
            var list = new List<TaskModel> { new TaskModel { Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1 } };
            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(list);

            var result = await _service.GetAll();

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetByIdShouldReturnUserWhenIdExists()
        {
            TaskModel task = new TaskModel { Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1 };
            _repository.Setup(repo => repo.GetById(task.Id)).ReturnsAsync(task);

            var result = await _service.GetById(task.Id);

            Assert.NotNull(result);
            Assert.Equal(task.Name, result.Name);
            Assert.Equal(task.Id, result.Id);

        }

        [Fact]
        public async Task GetByIdShouldThrowExceptionWhenIdDoesNotExist()
        {
            TaskModel task = new TaskModel { Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1 };
            _repository.Setup(repo => repo.GetById(task.Id)).ReturnsAsync(task);

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.GetById(2));
        }

        [Fact]
        public async Task CreateShouldReturnUser()
        {
            TaskModel task = new TaskModel { Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1 };
            _repository.Setup(repo => repo.Create(task)).ReturnsAsync(task);

            var result = await _service.Create(task);

            Assert.NotNull(result);
            Assert.Equal(task.Id, result.Id);
        }

        [Fact]
        public async Task UpdateShouldReturnUser()
        {
            TaskModel task = new TaskModel { Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1 };
            _repository.Setup(repo => repo.Update(task, task.Id)).ReturnsAsync(task);

            var result = await _service.Update(task, task.Id);

            Assert.NotNull(result);
            Assert.Equal(task.Id, result.Id);
            Assert.Equal(task.Name, result.Name);
            Assert.Equal(task.Description, result.Description);
            Assert.Equal(task.Status, result.Status);
            Assert.Equal(task.UserId, result.UserId);

        }

        [Fact]
        public async Task DeleteShouldReturnTrue()
        {
            TaskModel task = new TaskModel { Id = 1, Name = "Task 01", Description = "Description 1", Status = (TaskStatus)1, UserId = 1 };
            _repository.Setup(repo => repo.Delete(task.Id)).ReturnsAsync(true);

            var result = await _service.Delete(task.Id);

            Assert.True(result);
        }
    }
}
