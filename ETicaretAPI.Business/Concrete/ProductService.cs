using AutoMapper;
using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;
using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Business.Concrete;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public ReturnModel<ProductResponseDto> Add(ProductCreateRequest productCreateRequest)
    {
        Product product = _mapper.Map<Product>(productCreateRequest);
        _productRepository.Add(product);

        ProductResponseDto productResponseDto = _mapper.Map<ProductResponseDto>(product);
        return new ReturnModel<ProductResponseDto>()
        {
            Data = productResponseDto,
            Message = "Product Başarıyla Eklendi",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    public ReturnModel<ProductResponseDto> Delete(int id)
    {
        try
        {
            Product? product = _productRepository.GetById(id);
            _productRepository.Delete(id);
            ProductResponseDto productResponseDto = _mapper.Map<ProductResponseDto>(product);
            return new ReturnModel<ProductResponseDto>()
            {
                Data = productResponseDto,
                Message = "Product Silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<ProductResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<List<ProductResponseDto>> GetAll()
    {
        List<Product> products = _productRepository.GetAll();
        List<ProductResponseDto> productResponseDtos = _mapper.Map<List<ProductResponseDto>>(products);
        return new ReturnModel<List<ProductResponseDto>>()
        {
            Data = productResponseDtos,
            Message = "Productla rListelendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<ProductResponseDto> GetById(int id)
    {
        try
        {
            Product? product = _productRepository.GetById(id);
            ProductResponseDto productResponseDto = _mapper.Map<ProductResponseDto>(product);
            return new ReturnModel<ProductResponseDto>
            {
                Data = productResponseDto,
                Message = "Product Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<ProductResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<ProductResponseDto> Update(ProductUpdateRequest productUpdateRequest)
    {
        try
        {
            Product product = _mapper.Map<Product>(productUpdateRequest);
            _productRepository.Update(product);
            ProductResponseDto productResponseDto = _mapper.Map<ProductResponseDto>(product);
            return new ReturnModel<ProductResponseDto>
            {
                Data = productResponseDto,
                Message = $"{product.ProductName} adlı Product Güncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<ProductResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }
}
