using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTask.Aplication.DTOs;
using TeamTask.Domain.Interfaces;

namespace TeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(AuthUserRequest data) =>
             Ok(await _authServices.Auth(data));
    }
}
