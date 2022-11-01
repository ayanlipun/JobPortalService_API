using JobPortalService.Library.Interface;
using JobPortalService.Models;
using JobPortalService.Service.Helper;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalService.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            var resposne = _userService.Authenticate(authenticateRequest);
            if (Response == null)
                return BadRequest(new { message = "User Name or password is incorrect!" });

            return Ok(resposne);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}

