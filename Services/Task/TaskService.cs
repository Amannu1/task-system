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
            return await _repository.GetAll();
        }

        public async Task<TaskModel> GetById(int id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                throw new Exception($"Task with ID {id} not found.");
            }
            return user;
        }

        public async Task<TaskModel> Create(TaskModel model)
        {
            return await _repository.Create(model);
        }

        public async Task<TaskModel> Update(TaskModel model, int id)
        {
            return await _repository.Update(model, id);
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
