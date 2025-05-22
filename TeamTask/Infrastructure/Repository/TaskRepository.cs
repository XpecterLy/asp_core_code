using Microsoft.EntityFrameworkCore;
using TeamTask.Domain.Interfaces;
using TeamTask.Domain.Models;

namespace TeamTask.Infrastructure.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbTeamTaskContext _context;
        public TaskRepository(DbTeamTaskContext context)
        {   
            _context = context;
        }

        public async Task<IEnumerable<DtTask>> GetAllTask(string user_nit, int offset, int limit)
        {
            return await _context.DtTasks
                .Include(t => t.TaskList) 
                .Where(t => t.TaskList != null && t.TaskList.UserNit == user_nit) 
                .Skip(offset - 1)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<DtTask> GetTaskById(Guid id, string user_nit)
        {
            return await _context.DtTasks
                .FirstOrDefaultAsync(t =>
                    t.Id == id &&
                    t.TaskList.UserNit == user_nit
                );
        }

        public async Task<DtTask> InsertTask(DtTask data)
        {
            _context.DtTasks.Add(data);
            var res = await _context.SaveChangesAsync();
            if (res <= 0) return null;
            return data;
        }

        public async Task<DtTask> UpdateTask(DtTask data)
        {
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> DeleteTask(DtTask data)
        {
            _context.DtTasks.Remove(data);
            var res = await _context.SaveChangesAsync();
            if (res <= 0) return false;
            return true;
        }
    }
}
