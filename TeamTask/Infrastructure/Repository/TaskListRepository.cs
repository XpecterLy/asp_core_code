using Microsoft.EntityFrameworkCore;
using TeamTask.Domain.Interfaces;
using TeamTask.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamTask.Infrastructure.Repository
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly DbTeamTaskContext _context;
        public TaskListRepository(DbTeamTaskContext context)
        {   
            _context = context;
        }
        public async Task<IEnumerable<DtTaskList>> GetAllTaskList(string user_Nit, int offset, int limit)
        {
            return await _context.DtTaskLists
                .Where(t => t.UserNit == user_Nit)
                .Skip(offset - 1) 
                .Take(limit)
                .ToListAsync();
        }

        public async Task<DtTaskList> GetTaskListById(Guid id, string user_Nit)
        {
            return await _context.DtTaskLists.FirstOrDefaultAsync(e => e.Id == id && e.UserNit == user_Nit);
        }

        public async Task<DtTaskList> GetTaskListByName(string name, string user_Nit)
        {
            return await _context.DtTaskLists.FirstOrDefaultAsync(e => e.Name == name && e.UserNit == user_Nit);
        }

        public async Task<DtTaskList> InsertTaskList(DtTaskList data)
        {
            _context.DtTaskLists.Add(data);
            var res = await _context.SaveChangesAsync();
            if (res <= 0) return null;
            return data;
        }

        public async Task<DtTaskList> UpdateTaskList(DtTaskList data)
        {
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return data;
        }
        public async Task<bool> DeleteaskList(DtTaskList data)
        {
            _context.DtTaskLists.Remove(data);
            var res = await _context.SaveChangesAsync();
            if (res <= 0) return false;
            return true;
        }
    }
}
