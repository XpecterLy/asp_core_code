using ShopApi.Exceptions;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Enums;
using TeamTask.Domain.Interfaces;
using TeamTask.Domain.Models;

namespace TeamTask.Aplication.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskListService(
            ITaskListRepository taskListRepository, 
            IHttpContextAccessor httpContextAccessor)
        {
            _taskListRepository = taskListRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<ResponseTaskListDtos>> GetAllListTask(int offset,  int limit)
        {
            if (offset < 1)
                throw new BadRequestException("Param offset is less 1.");

            if (limit < 1)
                throw new BadRequestException("Param limit is less 1.");

            var nit_user = GetUserNitFromToken();

            var tasLists = await _taskListRepository.GetAllTaskList(nit_user, offset, limit);

            return tasLists
                .Select(t => new ResponseTaskListDtos{
                    Id = t.Id,
                    CreatedAt = t.CreatedAt,
                    Name = t.Name,
                    UpdatedAt = t.UpdatedAt,
                    Status = Enum.Parse<TaskListStatusEnum>(t.Status)
                });
        }
        public async Task<ResponseTaskListDtos> GetListTask(Guid id)
        {
            var nit_user = GetUserNitFromToken();

            var tasList = await _taskListRepository.GetTaskListById(id, nit_user);
            if (tasList == null) throw new NotFoundException("Task list is not found");

            return new ResponseTaskListDtos()
            {
                Id = tasList.Id,
                CreatedAt = tasList.CreatedAt,
                Name = tasList.Name,
                UpdatedAt = tasList.UpdatedAt,
                Status = Enum.Parse<TaskListStatusEnum>(tasList.Status)
            };
        }
        public async Task<ResponseTaskListDtos> InsertListTask(RequestTaskListDtos data)
        {
            var nit_user = GetUserNitFromToken();

            // Validate if exist tasklist name 
            if (await _taskListRepository.GetTaskListByName(data.Name, nit_user) != null) throw new ConflictException("Task list name already exist");

            var taskList = new DtTaskList()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = data.Name,
                Status = "Active",
                UserNit = nit_user
            };

            var tasList = await _taskListRepository.InsertTaskList(taskList);
            if (tasList == null) throw new Exception("Error to create task list");

            return new ResponseTaskListDtos()
            {
                Id = tasList.Id,
                CreatedAt = tasList.CreatedAt,
                Name = tasList.Name,
                UpdatedAt = tasList.UpdatedAt,
                Status = Enum.Parse<TaskListStatusEnum>(tasList.Status)
            };
        }
        public async Task<ResponseTaskListDtos> UpdateListTask(Guid id, RequestUpdateTaskListDtos data)
        {
            var nit_user = GetUserNitFromToken();


            // Validate if exist tasklist name 
            if(data.Name != null)
                if (await _taskListRepository.GetTaskListByName(data.Name, nit_user) != null) 
                    throw new ConflictException("Task list name already exist");

            var taskListOld = await _taskListRepository.GetTaskListById(id, nit_user);
            if (taskListOld == null) throw new NotFoundException("Task list not found");

            taskListOld.Name = (data.Name != null) ? data.Name : taskListOld.Name;
            taskListOld.Status = (data.Status != null) ? data.Status.ToString() : taskListOld.Status;

            var tasList = await _taskListRepository.UpdateTaskList(taskListOld);

            if (tasList == null) throw new Exception("Error to update task list");

            return new ResponseTaskListDtos()
            {
                Id = tasList.Id,
                CreatedAt = tasList.CreatedAt,
                Name = tasList.Name,
                UpdatedAt = tasList.UpdatedAt,
                Status = Enum.Parse<TaskListStatusEnum>(tasList.Status)
            };
        }
        public async Task<bool> DeleteListTask(Guid id)
        {
            var nit_user = GetUserNitFromToken();

            var taskList = await _taskListRepository.GetTaskListById(id, nit_user);
            if (taskList == null) throw new NotFoundException("Task list not found");

            var res = await _taskListRepository.DeleteaskList(taskList);

            if (res == false) throw new Exception("Error to delete task list");
            return true;
        }

        // Get userId from bearer token 
        private string GetUserNitFromToken()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var nit = user?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            if (string.IsNullOrWhiteSpace(nit))
                throw new BadRequestException("Bearer token is not valid");

            return nit.Trim();
        }
    }
}
