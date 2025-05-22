using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Interfaces;

namespace TeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{nit}")]
        [Authorize]
        public async Task<IActionResult> GetUser(string nit) =>
             Ok(await _userServices.GetUserByNit(nit));
        

        [HttpPost]
        public async Task<IActionResult> Register(UserDtos data)
        {
            var res = await _userServices.Register(data);
            return CreatedAtAction(nameof(GetUser), new { nit = res.nit }, res);
        }
    }
}
