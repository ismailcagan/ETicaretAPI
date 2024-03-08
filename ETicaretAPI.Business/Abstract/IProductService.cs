using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;

namespace ETicaretAPI.Business.Abstract;
public interface IProductService
{
    ReturnModel<ProductResponseDto> Add(ProductCreateRequest productCreateRequest);
    ReturnModel<ProductResponseDto> Update(ProductUpdateRequest productUpdateRequest);
    ReturnModel<ProductResponseDto> Delete(int id);
    ReturnModel<List<ProductResponseDto>> GetAll();
    ReturnModel<ProductResponseDto> GetById(int id);
}
