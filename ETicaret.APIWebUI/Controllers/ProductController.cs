using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Concrete;
using ETicaretAPI.Business.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost("Product Ekle")]
        public IActionResult Add([FromForm]ProductCreateRequest createRequest)
        {
            var result = _service.Add(createRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return Created("/", result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Product Sil")]
        public IActionResult Delete(int id)
        {
            var user = _service.Delete(id);
            if (user.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }

        [HttpPut("Product Güncelle")]
        public IActionResult Update(ProductUpdateRequest updateRequest)
        {
            var result = _service.Update(updateRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Product Listele")]
        public IActionResult GetList()
        {
            var result = _service.GetAll();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Product Getir")]
        public IActionResult GetById(int id)
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
