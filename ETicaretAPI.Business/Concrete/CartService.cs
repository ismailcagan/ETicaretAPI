using AutoMapper;
using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;
using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;
using ETicaretAPI.Model.ViewModel;

namespace ETicaretAPI.Business.Concrete;
public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartService(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public ReturnModel<CartResponseDto> Add(CartCreateRequest cartCreateRequest)
    {
        Cart cart = _mapper.Map<Cart>(cartCreateRequest);
        _cartRepository.Add(cart);

        CartResponseDto response = _mapper.Map<CartResponseDto>(cart);
        return new ReturnModel<CartResponseDto>
        {
            Data = response,
            Message = "Ürün Cartta Eklendi",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public ReturnModel<CartResponseDto> Delete(int id)
    {
        try
        {
            Cart? cart = _cartRepository.GetById(id);
            _cartRepository.Delete(id);
            CartResponseDto cartResponseDto = _mapper.Map<CartResponseDto>(cart);
            return new ReturnModel<CartResponseDto>
            {
                Data = cartResponseDto,
                Message = "Carttaki Ürün Silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };

        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<CartResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<List<CartResponseDto>> GetAll()
    {
        List<Cart> carts = _cartRepository.GetAll();
        List<CartResponseDto> cartResponseDtos = _mapper.Map<List<CartResponseDto>>(carts);
        return new ReturnModel<List<CartResponseDto>>
        {
            Data = cartResponseDtos,
            Message = "Carttaki Ürünler Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<CartResponseDto> GetById(int id)
    {
        try
        {
            Cart? cart = _cartRepository.GetById(id);
            CartResponseDto cartResponseDto = _mapper.Map<CartResponseDto>(cart);
            return new ReturnModel<CartResponseDto>
            {
                Data = cartResponseDto,
                Message = "Cart Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {

            return new ReturnModel<CartResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<List<UserToProduct>> GetToUser(int userId)
    {
        List<UserToProduct> userToProducts = _cartRepository.UserToProduct(userId);
        return new ReturnModel<List<UserToProduct>>
        {
            Data = userToProducts,
            Message = "User Göre Cart Getirildi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
