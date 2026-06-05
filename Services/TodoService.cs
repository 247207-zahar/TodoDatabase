
using Microsoft.EntityFrameworkCore;
using TodoDatabase.Data;
namespace TodoDatabase.Services
{
    public class TodoService
    {
        private readonly AppDbContext _context;
        public TodoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }
        public async Task AddAsync(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TodoItem item)
        {
            _context.TodoItems.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}