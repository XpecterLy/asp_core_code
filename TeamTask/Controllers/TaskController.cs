using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTask.Aplication.DTOs;
using TeamTask.Aplication.Services;
using TeamTask.Domain.Interfaces;
using TeamTask.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;
        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllTask(int offset = 1, int limit = 10)
            => Ok(await _taskServices.GetAll(offset, limit));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
            => Ok(await _taskServices.GetById(id));

        [HttpPost]
        public async Task<IActionResult> InsertTask(RequestInsertTaskDtos data)
        {
            var res = await _taskServices.InsertTask(data);
            return CreatedAtAction(nameof(GetTask), new {id = res.Id }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, RequestUpdateTaskDtos data)
            => Ok(await _taskServices.UpdateTask(id, data));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _taskServices.DeleteTask(id);
            return Ok();
        }
    }
}
