using TaskSystem.Models;

namespace TaskSystem.Repository.Interface
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> findAllTasks();
        Task<TaskModel> findById(int id);
        Task<TaskModel> createTask(TaskModel task);
        Task<TaskModel> updateTask(TaskModel task, int id);
        Task<bool> deleteTask(int id);
    }
}
