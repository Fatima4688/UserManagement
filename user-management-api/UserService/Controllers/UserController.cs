using Microsoft.AspNetCore.Mvc;
using UserService.Services.Interfaces;

namespace MissionManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] Common.Models.ViewModels.User user )
        {
            Common.ViewModels.ResponseViewModel response = await _userService.CreateUser(user);
            return StatusCode(response.Status, response.Response);
        }

        [HttpDelete]
        [Route("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            Common.ViewModels.ResponseViewModel response = await _userService.DeleteUser(userId);
            return StatusCode(response.Status, response.Response);
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            Common.ViewModels.ResponseViewModel response = await _userService.GetUsers();
            return StatusCode(response.Status, response.Response);
        }
    }
}