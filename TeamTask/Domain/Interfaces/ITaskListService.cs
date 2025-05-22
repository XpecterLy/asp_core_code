using TeamTask.Aplication.DTOs;

namespace TeamTask.Domain.Interfaces
{
    public interface ITaskListService
    {
        public Task<IEnumerable<ResponseTaskListDtos>> GetAllListTask(int offset, int limit);
        public Task<ResponseTaskListDtos> GetListTask(Guid id);
        public Task<ResponseTaskListDtos> InsertListTask(RequestTaskListDtos data);
        public Task<ResponseTaskListDtos> UpdateListTask(Guid id, RequestUpdateTaskListDtos data);
        public Task<bool> DeleteListTask(Guid id);
    }
}
