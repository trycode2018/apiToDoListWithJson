using ApiToDoJson.Interfaces;
using ApiToDoJson.Models;
using System.Text.Json;

namespace ApiToDoJson.Repositories
{
    public class ToDoRepository:IToDoRepository
    {
        private const string FilePath = "Data/Database.json";

        public async Task AddAsync(ToDoItem item)
        {
            var todos = (await GetAllAsync()).ToList();
            item.Id = todos.Any() ? todos.Max(t => t.Id) + 1 : 1;
            todos.Add(item);
            await SaveToFileAsync(todos);
        }

        public async Task DeleteAsync(int id)
        {
            var todos = (await GetAllAsync()).ToList();
            var todoToRemove = todos.FirstOrDefault(t => t.Id == id);
            if (todoToRemove != null)
            {
                todos.Remove(todoToRemove);
                await SaveToFileAsync(todos);
            }
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            if(!File.Exists(FilePath)) 
                return new List<ToDoItem>();

            var jsonData = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<ToDoItem>>(jsonData) ?? new List<ToDoItem>();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            var todos = await GetAllAsync();
            return todos.FirstOrDefault(t => t.Id == id);
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            var todos = (await GetAllAsync()).ToList();
            var index = todos.FindIndex(t=>t.Id == item.Id);
            if (index != -1)
            {
                todos[index] = item;
                await SaveToFileAsync(todos);
            }
        }

        public async Task SaveToFileAsync(IEnumerable<ToDoItem> item)
        {
            var jsonData = JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented=true});
            await File.WriteAllTextAsync(FilePath, jsonData);
        }
    }
}
