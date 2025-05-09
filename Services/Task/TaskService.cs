using TaskSystem.Models;
using TaskSystem.Repository.Interface;

namespace TaskSystem.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskModel>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<TaskModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<TaskModel> Create(TaskModel model)
        {
            throw new NotImplementedException();
        }
        public Task<TaskModel> Update(TaskModel model, int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
