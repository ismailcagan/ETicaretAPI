using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("User Ekle")]
        public IActionResult Add(UserCreateRequest createRequest)
        {
            var result = _userService.Add(createRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return Created("/", result);
            }
            return BadRequest(result);
        }

        [HttpDelete("User Sil")]
        public IActionResult Delete(int id)
        {
            var user = _userService.Delete(id);
            if (user.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }

        [HttpPut("User Güncelle")]
        public IActionResult Update(UserUpdateRequest updateRequest)
        {
            var result = _userService.Update(updateRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("User Listele")]
        public IActionResult GetList()
        {
            var result = _userService.GetAll();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("User Getir")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
