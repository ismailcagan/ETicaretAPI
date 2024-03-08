using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpPost("Admin Ekle")]
        public IActionResult Add([FromForm]AdminCreateRequest request)
        {
            var result = _service.Add(request);
            if(result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return Created("/", result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Admin Sil")]
        public IActionResult Delete([FromForm]int id)
        {
            var result = _service.Delete(id);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Admin Güncelle")]
        public IActionResult Update([FromForm] AdminUpdateRequest request)
        {
            var result = _service.Update(request);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Admin Listele")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Admin Getir")]
        public IActionResult GetById([FromForm] int id)
        {
            var result = _service.GetById(id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
