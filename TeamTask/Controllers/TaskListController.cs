using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Interfaces;

namespace TeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _taskListService;
        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskList(int offset = 1, int limit = 10)
            => Ok(await _taskListService.GetAllListTask(offset, limit));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskList(Guid id)
            => Ok(await _taskListService.GetListTask(id));

        [HttpPost]
        public async Task<IActionResult> InsertTaskList(RequestTaskListDtos data)
        {
            var res = await _taskListService.InsertListTask(data);
            return CreatedAtAction(nameof(GetTaskList), new {id= res.Id}, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskList(Guid id, RequestUpdateTaskListDtos data) 
            => Ok(await _taskListService.UpdateListTask(id, data));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskList(Guid id)
        {
            await _taskListService.DeleteListTask(id);
            return Ok();
        }
    }
}
