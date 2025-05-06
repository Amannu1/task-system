using TaskSystem.Models;

namespace TaskSystem.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserModel>> findAllUsers();
        Task<UserModel> findById(int id);
        Task<UserModel> createUser(UserModel user);
        Task<UserModel> updateUser(UserModel user, int id);
        Task<bool> deleteUser(int id);
    }
}
