using AutoMapper;
using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;
using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Business.Concrete;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public ReturnModel<CategoryResponseDto> Add(CategoryCreateRequest response)
    {
        Category category = _mapper.Map<Category>(response);
        _categoryRepository.Add(category);
        CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>()
        {
            Data = categoryResponseDto,
            Message = "Category Eklendi",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public ReturnModel<CategoryResponseDto> Delete(int id)
    {
        try
        {
            Category category = _categoryRepository.GrtById(id);
            _categoryRepository.Delete(id);
            CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);
            return new ReturnModel<CategoryResponseDto>()
            {
                Data = categoryResponseDto,
                Message = "Category Silindi",
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<CategoryResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }
}
