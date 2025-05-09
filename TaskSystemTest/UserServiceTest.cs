using Moq;
using TaskSystem.Models;
using TaskSystem.Repository;
using TaskSystem.Repository.Interface;
using TaskSystem.Services.User;

namespace TaskSystemTest
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _repository;
        private readonly UserService _service;

        public UserServiceTest()
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
            var user = new UserModel { Id = 1, Name = "Manu", Email = "manu@gmail.com" };
            _repository.Setup(repo => repo.GetById(user.Id)).ReturnsAsync(user);

            var result = await _service.GetById(user.Id);

            Assert.Equal(1, result.Id);
        }
        [Fact]
        public async Task GetByIdShouldThrowExceptionWhenUserDoesNotExist()
        {
            var user = new UserModel { Id = 1, Name = "Manu", Email = "manu@gmail.com" };
            _repository.Setup(repo => repo.GetById(user.Id)).ReturnsAsync(user);

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.GetById(2));
            
        }
    }
}