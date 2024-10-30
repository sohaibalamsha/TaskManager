using TASK_SYS.Data;
using TASK_SYS.Services.Interfaces;

namespace TASK_SYS.Services
{
    public class TaskService : ITaskService
    {
        private readonly AuthDbContext _context;

        public TaskService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetTasksAsync() => await _context.Tasks.ToListAsync();

        public async Task<Task> GetTaskByIdAsync(int id) => await _context.Tasks.FindAsync(id);

        public async Task CreateTaskAsync(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
