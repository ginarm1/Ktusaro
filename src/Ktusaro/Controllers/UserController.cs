using AutoMapper;
using Ktusaro.Core.Models;
using Ktusaro.Services.Services;
using Ktusaro.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ktusaro.WebApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Ok(_mapper.Map<List<User>>(users));
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(CreateUserRegister request)
        {
            var user = _mapper.Map<User>(request);

            var registeredUser = await _userService.Register(user,request.Password);
            return Ok(registeredUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(CreateUserLogin request)
        {
            var user = _mapper.Map<User>(request);

            var logedUserToken = await _userService.Login(user, request.Password);
            return Ok(logedUserToken);
        }
    }
}
