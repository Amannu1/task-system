using TaskSystem.Models;

namespace TaskSystem.Services.Task
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAll();
        Task<TaskModel> GetById(int id);
        Task<TaskModel> Create(TaskModel model);
        Task<TaskModel> Update(TaskModel model, int id);
        Task<bool> Delete(int id);
    }
}
