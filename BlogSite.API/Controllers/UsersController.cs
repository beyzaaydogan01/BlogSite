using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstratcts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateUserRequest dto)
        {
            var result = _userService.Add(dto);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var result = _userService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] long id)
        {
            var result = _userService.Delete(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateUserRequest dto)
        {
            var result = _userService.Update(dto);
            return Ok(result);
        }
    }
}
