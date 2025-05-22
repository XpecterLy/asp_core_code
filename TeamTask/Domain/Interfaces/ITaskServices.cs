using TeamTask.Aplication.DTOs;

namespace TeamTask.Domain.Interfaces
{
    public interface ITaskServices
    {
        public Task<IEnumerable<ReturnTaskDtos>> GetAll(int offset, int limit);
        public Task<ReturnTaskDtos> GetById(Guid Id);
        public Task<ReturnTaskDtos> InsertTask(RequestInsertTaskDtos data);
        public Task<ReturnTaskDtos> UpdateTask(Guid Id, RequestUpdateTaskDtos data);
        public Task<bool> DeleteTask(Guid Id);
    }
}
