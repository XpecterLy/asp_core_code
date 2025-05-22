using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Models;

namespace TeamTask.Domain.Interfaces
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<DtTask>> GetAllTask(string user_Nit, int offset, int limit);
        public Task<DtTask> GetTaskById(Guid id, string user_Nit);
        public Task<DtTask> InsertTask(DtTask data);
        public Task<DtTask> UpdateTask(DtTask data);
        public Task<bool> DeleteTask(DtTask data);
    }
}
