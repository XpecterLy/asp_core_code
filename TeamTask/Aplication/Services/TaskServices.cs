using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Exceptions;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Builder;
using TeamTask.Domain.Interfaces;
using TeamTask.Domain.Models;

namespace TeamTask.Aplication.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskListRepository _taskListRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaskServices(
            ITaskListRepository taskListRepository, 
            ITaskRepository taskRepository, 
            IHttpContextAccessor httpContextAccessor
            )
        {
            _taskListRepository = taskListRepository;
            _taskRepository = taskRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<ReturnTaskDtos>> GetAll(int offset, int limit)
        {
            if (offset < 1)
                throw new BadRequestException("Param offset is less 1.");

            if (limit < 1)
                throw new BadRequestException("Param limit is less 1.");

            var user_nit = GetUserNitFromToken();

            var tasks = await _taskRepository.GetAllTask(user_nit, offset, limit);
            return tasks.Select(x => new ReturnTaskDtos
            {
                TaskListId = x.TaskListId,
                CreatedAt = x.CreatedAt,
                Descripcion = x.Descripcion,
                DueDate = x.DueDate,
                IsCompleted = x.IsCompleted,
                Id = x.Id,
                Titulo = x.Titulo,
                UpdatedAt = x.UpdatedAt,
            });
        }

        public async Task<ReturnTaskDtos> GetById(Guid Id)
        {
            var user_nit = GetUserNitFromToken();

            var task = await _taskRepository.GetTaskById(Id, user_nit);

            if (task == null) throw new NotFoundException("Task is not found");

            return new ReturnTaskDtos {

                TaskListId = task.TaskListId,
                CreatedAt = task.CreatedAt,
                Descripcion = task.Descripcion,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted,
                Id = task.Id,
                Titulo = task.Titulo,
                UpdatedAt = task.UpdatedAt,
            };
        }

        public async Task<ReturnTaskDtos> InsertTask(RequestInsertTaskDtos data)
        {
            var user_nit = GetUserNitFromToken();

            var existTaskList = await _taskListRepository.GetTaskListById(data.TaskListId, user_nit);

            if (existTaskList == null) throw new BadRequestException("Task list is not found");

            var task = new TaskBuilder()
                .WithTaskListId(data.TaskListId)
                .WithTitle(data.Titulo)
                .WithDescription(data.Descripcion)
                .WithDueDate(data.DueDate)
                .Build();

            var res = await _taskRepository.InsertTask(task);

            if (res == null) throw new Exception();

            return new ReturnTaskDtos
            {
                TaskListId = data.TaskListId,
                CreatedAt = res.CreatedAt,
                Descripcion = res.Descripcion,
                DueDate = res.DueDate,
                IsCompleted = res.IsCompleted,
                Id = res.Id,
                Titulo = res.Titulo,
                UpdatedAt = res.UpdatedAt,
            };
        }

        public async Task<ReturnTaskDtos> UpdateTask(Guid Id, RequestUpdateTaskDtos data)
        {
            var user_nit = GetUserNitFromToken();

            var task = await _taskRepository.GetTaskById(Id, user_nit);

            if (task == null) throw new NotFoundException("Task is not found");

            task.Titulo = (data.Titulo != null) ? data.Titulo : task.Titulo;
            task.Descripcion = (data.Descripcion != null) ? data.Descripcion : task.Descripcion;
            task.DueDate = (data.DueDate != null) ? data.DueDate : task.DueDate;
            task.IsCompleted = data.IsCompleted ?? task.IsCompleted;
            task.UpdatedAt = DateTime.Now;


            var res = await _taskRepository.UpdateTask(task);

            if (res == null) throw new Exception("Error to update task");

            return new ReturnTaskDtos 
            {
                TaskListId = res.TaskListId,
                CreatedAt = res.CreatedAt,
                Descripcion = res.Descripcion,
                DueDate = res.DueDate,
                IsCompleted = res.IsCompleted,
                Id = res.Id,
                Titulo = res.Titulo,
                UpdatedAt = res.UpdatedAt,
            };
        }
        public async Task<bool> DeleteTask(Guid Id)
        {
            var user_nit = GetUserNitFromToken();

            var task = await _taskRepository.GetTaskById(Id, user_nit);

            if (task == null) throw new NotFoundException("Task is not found");

            var res = await _taskRepository.DeleteTask(task);

            if (res == false) throw new Exception("Error to delete task");

            return true;
        }

        // Get userId from bearer token 
        private string GetUserNitFromToken()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var nit = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (nit == null) throw new BadRequestException("Bearer token is not valid");
            return nit;
        }
    }
}
