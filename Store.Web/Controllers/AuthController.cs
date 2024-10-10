using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Serveses.UserService;
using Store.Serveses.UserService.DTOs;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(RegsterDTO regsterDTO)
        {
            var user = await userService.Register(regsterDTO);
            if (user == null)
                return BadRequest(new Exception("Alrady Exist"));

            return Ok(user);

        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await userService.login(loginDTO);
            if (user == null)
                return BadRequest(new Exception("not Exist"));

            return Ok(user);

        }
    }
}
