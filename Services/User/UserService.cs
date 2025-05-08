using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;   
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<UserModel> GetById(int id)
        {
            var user = await _repository.GetById(id);
            if(user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            return user;
        }
        public async Task<UserModel> Create(UserModel model)
        {
            return await _repository.Create(model);
        }

        public async Task<UserModel> Update(UserModel model, int id)
        {
            return await _repository.Update(model, id);
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
