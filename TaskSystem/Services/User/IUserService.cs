using TaskSystem.Models;

namespace TaskSystem.Services.User
{
    public interface IUserService
    {
        Task<UserModel> GetById(int id);
        Task<List<UserModel>> GetAll();
        Task<UserModel> Create(UserModel model);
        Task<UserModel> Update(UserModel model, int id);
        Task<bool> Delete(int id);
    }
}
