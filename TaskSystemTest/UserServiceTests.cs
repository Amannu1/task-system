using Moq;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;
using TaskSystem.Services.User;

namespace TaskSystemTest
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _repository;
        private readonly UserService _service;

        public UserServiceTests()
        {
            _repository = new Mock<IUserRepository>();
            _service = new UserService(_repository.Object);
        }

        [Fact]
        public async Task GetAllShouldReturnUserList()
        {
            var list = new List<UserModel> { new UserModel{Id = 1, Name = "Manu", Email = "email@email.com" }
            };

            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(list);

            var result = await _service.GetAll();

            Assert.Single(result);
        }
        [Fact]
        public async Task GetByIdShouldReturnExistingUser()
        {
            UserModel user = new UserModel { Id = 1, Name = "Manu", Email = "manu@gmail.com" };
            _repository.Setup(repo => repo.GetById(user.Id)).ReturnsAsync(user);

            var result = await _service.GetById(user.Id);

            Assert.Equal(user.Id, result.Id);
        }
        [Fact]
        public async Task GetByIdShouldThrowExceptionWhenUserDoesNotExist()
        {
            UserModel user = new UserModel { Id = 1, Name = "Manu", Email = "manu@gmail.com" };
            _repository.Setup(repo => repo.GetById(user.Id)).ReturnsAsync(user);

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.GetById(2));
            
        }

        [Fact]
        public async Task CreateShouldReturnUser()
        {
            UserModel user = new UserModel { Id = 1, Name = "Manu", Email = "manu@gmail.com" };
            _repository.Setup(repo => repo.Create(user)).ReturnsAsync(user);

            var result = await _service.Create(user);

            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }

        [Fact]
        public async Task UpdateShouldReturnUserWhenIdExists()
        {
            UserModel user = new UserModel { Id = 1, Name = "Manu", Email = "manu@gmail.com" };
            _repository.Setup(repo => repo.Update(user, user.Id)).ReturnsAsync(user);

            var result = await _service.Update(user, user.Id);

            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.Email, result.Email);
        }

        [Fact]
        public async Task DeleteShouldReturnTrue()
        {
           UserModel user = new UserModel { Id = 1, Name = "Manu", Email = "manu@gmail.com" };

            _repository.Setup(repo => repo.Delete(user.Id)).ReturnsAsync(true);

            var result = await _service.Delete(user.Id);

            Assert.True(result);
        }
    }
}