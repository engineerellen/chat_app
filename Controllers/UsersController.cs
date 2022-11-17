using chat_test.DTO.Users;
using chat_test.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chat_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddUserDto user)
        {
            return Ok(await _userService.AddUser(user));
        }
    }
}
