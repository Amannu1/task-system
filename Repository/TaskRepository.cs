using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<TaskModel> findById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> findAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> createTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> updateTask(TaskModel task, int id)
        {
            TaskModel taskById = await findById(id);
            if (taskById == null)
            {
                throw new Exception($"Task for the given ID: {id} not found in database.");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> deleteTask(int id)
        {
            TaskModel taskById = await findById(id);

            if (taskById == null)
            {
                throw new Exception($"Task for the given ID: {id} not found in database.");
            }


            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }   
    }
}
