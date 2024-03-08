using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("Category Ekle")]
    public IActionResult Add([FromForm]CategoryCreateRequest request)
    {
        var result = _categoryService.Add(request);
        if(result.StatusCode == System.Net.HttpStatusCode.Created)
        {
            return Created("/", result);
        }
        return BadRequest(result);
    }

    [HttpDelete("Category Sil")]
    public IActionResult Delete(int id)
    {
        var result = _categoryService.Delete(id);
        if(result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
