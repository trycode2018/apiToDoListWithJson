using ApiToDoJson.Models;

namespace ApiToDoJson.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(int id);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(int id,ToDoItem item);
        Task DeleteAsync(int id);
    }
}
