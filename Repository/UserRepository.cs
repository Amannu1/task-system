using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<UserModel> findById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> findAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }  

        public async Task<UserModel> createUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> updateUser(UserModel user, int id)
        {
            UserModel userById = await findById(id);
            if (userById == null)
            {
                throw new Exception($"User for the given ID: {id} not found in database.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email; 

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> deleteUser(int id)
        {
            UserModel userById = await findById(id);
            if (userById == null)
            {
                throw new Exception($"User for the given ID: {id} not found in database.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
