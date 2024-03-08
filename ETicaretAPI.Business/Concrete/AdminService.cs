using AutoMapper;
using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;
using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private IMapper _mapper;

    public AdminService(IAdminRepository adminRepository, IMapper mapper)
    {
        _adminRepository = adminRepository;
        _mapper = mapper;
    }

    public ReturnModel<AdminResponseDto> Add(AdminCreateRequest adminCreateRequest)
    {
        Admin? admin = _mapper.Map<Admin>(adminCreateRequest);
        _adminRepository.Add(admin);
        AdminResponseDto adminResponse = _mapper.Map<AdminResponseDto>(admin);
        return new ReturnModel<AdminResponseDto>()
        {
            Data = adminResponse,
            Message = "Admin Başarı bir şekilde eklendi",
            StatusCode = System.Net.HttpStatusCode.Created,
        };
    }

    public ReturnModel<AdminResponseDto> Delete(int id)
    {
        try
        {
            Admin? admin = _adminRepository.GetById(id);
            _adminRepository.Delete(id);
            AdminResponseDto adminResponse = _mapper.Map<AdminResponseDto>(admin);
            return new ReturnModel<AdminResponseDto>()
            {
                Data = adminResponse,
                Message = "Admin Başarıyla Silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<AdminResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<List<AdminResponseDto>> GetAll()
    {
        List<Admin> admins = _adminRepository.GetAll();
        List<AdminResponseDto> adminResponseDtos = _mapper.Map<List<AdminResponseDto>>(admins);
        return new ReturnModel<List<AdminResponseDto>>()
        {
            Data = adminResponseDtos,
            Message = "Bütün Adminler Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<AdminResponseDto> GetById(int id)
    {
        try
        {
            Admin? admin = _adminRepository.GetById(id);
            AdminResponseDto adminResponseDto = _mapper.Map<AdminResponseDto>(admin);
            return new ReturnModel<AdminResponseDto>()
            {
                Data = adminResponseDto,
                Message = $"{admin.AdminName} Adlı Admin Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<AdminResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<AdminResponseDto> Update(AdminUpdateRequest adminUpdateRequest)
    {
        try
        {
            Admin admin = _mapper.Map<Admin>(adminUpdateRequest);
            _adminRepository.Update(admin);

            AdminResponseDto adminResponseDto = _mapper.Map<AdminResponseDto>(admin);
            return new ReturnModel<AdminResponseDto>()
            {
                Data = adminResponseDto,
                Message = "Admin Güncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<AdminResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
       
       
    }
}
