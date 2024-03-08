using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpPost("Cart Ekle")]
        public IActionResult Add([FromForm]CartCreateRequest request)
        {
            var result = _service.Add(request);
            if(result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return Created("/", result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Cart Sil")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Cart Listele")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Cart Getir")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("User To Cart")]
        public IActionResult GetByUserToCart([FromQuery]int userId)
        {
            var result = _service.GetToUser(userId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
