using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;
using ETicaretAPI.Model.ViewModel;

namespace ETicaretAPI.Business.Abstract;
public interface ICartService
{
    ReturnModel<CartResponseDto> Add(CartCreateRequest cartCreateRequest);
    ReturnModel<CartResponseDto> Delete(int id);
    ReturnModel<List<CartResponseDto>> GetAll();
    ReturnModel<CartResponseDto> GetById(int id);
    // ReturnModel<List<UserToCartResponseDto>> GetToUser(int userId);
    ReturnModel<List<UserToProduct>> GetToUser(int userId);
}
