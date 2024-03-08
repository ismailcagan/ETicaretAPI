using AutoMapper;
using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Model.Entity;
using ETicaretAPI.Model.ViewModel;

namespace ETicaretAPI.WebUI.Profiles.Mapping;
public class ProfilesMappings : Profile
{
    public ProfilesMappings()
    {
        // ADMİN
        CreateMap<AdminCreateRequest, Admin>();
        CreateMap<AdminUpdateRequest, Admin>();
        CreateMap<Admin, AdminResponseDto>();

        // USER
        CreateMap<UserCreateRequest ,User>();
        CreateMap<UserUpdateRequest ,User>();
        CreateMap<User, UserResponseDto>();

        // Product 
        CreateMap<ProductCreateRequest ,Product>();
        CreateMap<ProductUpdateRequest ,Product>();
        CreateMap<Product, ProductResponseDto>();

        // Category
        CreateMap<CategoryCreateRequest, Category>();
        CreateMap<CategoryUpdateRequest, Category>();
        CreateMap<Category, CategoryResponseDto>();

        // Cart
        CreateMap<CartCreateRequest, Cart>();
        CreateMap<Cart, CartResponseDto>();

        // UserToCart
        CreateMap<UserToProduct, UserToCartResponseDto>();
    }
}
