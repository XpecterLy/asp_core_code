using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Models;

namespace TeamTask.Domain.Interfaces
{
    public interface ITaskListRepository
    {
        public Task<IEnumerable<DtTaskList>> GetAllTaskList(string user_Nit, int offset, int limit);
        public Task<DtTaskList> GetTaskListById(Guid id, string user_Nit);
        public Task<DtTaskList> GetTaskListByName(string name, string user_Nit);
        public Task<DtTaskList> InsertTaskList(DtTaskList data);
        public Task<DtTaskList> UpdateTaskList(DtTaskList data);
        public Task<bool> DeleteaskList(DtTaskList data);
    }
}
