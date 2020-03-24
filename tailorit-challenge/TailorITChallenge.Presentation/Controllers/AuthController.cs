using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using TailorITChallenge.Application.Interfaces;
using TailorITChallenge.Application.DTO;

namespace TailorITChallenge.TailorITChallenge.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthServiceApp _authService;

        public AuthController(IAuthServiceApp authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody]AuthDTO model)
        {
            var auth = _authService.Authenticate(model.Username, model.Password);

            if (auth == null)
                return BadRequest(new { message = "Username or password is incorrect!" });

            return Ok(auth);
        }
    }
}
