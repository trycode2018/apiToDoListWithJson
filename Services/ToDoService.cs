using ApiToDoJson.Interfaces;
using ApiToDoJson.Models;

namespace ApiToDoJson.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository) => _repository = repository;
        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ToDoItem item)
        {
            item.CreatedAt = DateTime.Now;
            item.IsCompleted = false;
            await _repository.AddAsync(item);
        }

        public async Task UpdateAsync(int id, ToDoItem item)
        {
            var existingItem = await _repository.GetByIdAsync(id);
            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.IsCompleted = item.IsCompleted;
                existingItem.Description = item.Description;
                await _repository.UpdateAsync(existingItem);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
