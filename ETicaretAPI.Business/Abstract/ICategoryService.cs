using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;

namespace ETicaretAPI.Business.Abstract;
public interface ICategoryService
{
    ReturnModel<CategoryResponseDto> Add(CategoryCreateRequest response);
    ReturnModel<CategoryResponseDto> Delete(int id);
}
