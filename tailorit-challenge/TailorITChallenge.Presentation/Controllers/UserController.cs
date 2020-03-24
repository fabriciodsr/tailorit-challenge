using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailorITChallenge.Application.DTO;
using TailorITChallenge.Application.Interfaces;

namespace TailorITChallenge.TailorITChallenge.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserServiceApp _userService;

        public UserController(IUserServiceApp userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(string search = "", bool somenteAtivos = false)
        {
            var users = _userService.SelectAll();

            if (String.IsNullOrEmpty(search) && !somenteAtivos)
                return Ok(users);

            if (String.IsNullOrEmpty(search) && somenteAtivos)
                return Ok(users.Where(x => x.Active == somenteAtivos));

            if (!String.IsNullOrEmpty(search) && !somenteAtivos)
                return Ok(users.Where(x => x.Name.ToLower().Contains(search.ToLower())));

            if (!String.IsNullOrEmpty(search) && somenteAtivos)
                return Ok(users.Where(x => x.Name.ToLower().Contains(search.ToLower()) && x.Active == somenteAtivos));

            return Ok(users);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int Id)
        {
            var user = _userService.SelectById(Id);

            if (user == null)
                return BadRequest(new { message = "There are no users with that Id!" });

            return Ok(user);
        }

        [HttpPut("PutUser/{id:int}")]
        public IActionResult PutUser(int id, UserDTO user)
        {
            if (user.Id != id)
                return BadRequest(new { message = "Information mismatch!" });

            _userService.Update(user);
            return Ok(user);
        }

        [HttpPost("PostUser")]
        public IActionResult PostUser(UserDTO user)
        {
            var registeredUser = _userService.Insert(user);
            if (registeredUser > 0)
                return Ok(registeredUser);

            return BadRequest(new { message = "The user registration has failed!" });
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteById(id);

            var user = _userService.SelectById(id);
            if (user == null)
                return Ok();

            return BadRequest(new { message = "The user removal has failed!" });
        }

        [HttpPut("PutUserState/{id:int}")]

        public IActionResult PutUserState(int id, UserDTO user)
        {
            if (user.Id != id)
                return BadRequest(new { message = "Information mismatch!" });

            user.Active = !user.Active;
            _userService.Update(user);
            return Ok();
        }
    }
}