using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Service.Abstratcts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentService _commentService) : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _commentService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateCommentRequest dto)
        {
            var result = _commentService.Add(dto);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _commentService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var result = _commentService.Delete(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateCommentRequest dto)
        {
            var result = _commentService.Update(dto);
            return Ok(result);
        }
    }
}
