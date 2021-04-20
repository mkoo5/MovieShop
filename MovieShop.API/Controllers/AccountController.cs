using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel model)
        {
            var user = await _userService.ValidateUser(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var jwtToken = _jwtService.GenerateToken(user);

            return Ok( new { token = jwtToken });
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<ActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserDetails(id);
            return Ok(user);
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterUserAsync(UserRegisterRequestModel user)
        {
            var createdUser = await _userService.RegisterUser(user);
            //return CreatedAtRoute("GetUser", new {id = createdUser.Id}, createdUser);
            return Ok();
        }

        [HttpGet]
        [Route("emailexists")]
        public async Task<ActionResult> EmailExists([FromQuery] string email)
        {
            var user = await _userService.GetUser(email);
            return Ok(user == null ? new {emailExists = false} : new {emailExists = true});
        }
    }
}
