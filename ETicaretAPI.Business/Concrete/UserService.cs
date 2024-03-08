using AutoMapper;
using ETicaretAPI.Business.Abstract;
using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;
using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Business.Concrete;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public ReturnModel<UserResponseDto> Add(UserCreateRequest createRequest)
    {
        User user = _mapper.Map<User>(createRequest);
        _userRepository.Add(user);

        UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);
        return new ReturnModel<UserResponseDto>()
        {
            Data = userResponseDto,
            Message = "Kullanıcı Kaydedildi",
            StatusCode = System.Net.HttpStatusCode.Created
        };
    }

    public ReturnModel<UserResponseDto> Delete(int id)
    {
        try
        {
            User? user = _userRepository.GetById(id);
            _userRepository.Delete(id);
            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);
            return new ReturnModel<UserResponseDto>()
            {
                Data = userResponseDto,
                Message = "Kullanıcı Kaydı Silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<UserResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public ReturnModel<List<UserResponseDto>> GetAll()
    {
        List<User> users = _userRepository.GetAll();

        List<UserResponseDto> userResponseDto = _mapper.Map<List<UserResponseDto>>(users);
        return new ReturnModel<List<UserResponseDto>>()
        {
            Data = userResponseDto,
            Message = "Userlar Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK,
        };

    }

    public ReturnModel<UserResponseDto> GetById(int id)
    {
        try
        {
            User? user = _userRepository.GetById(id);
            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);
            return new ReturnModel<UserResponseDto>()
            {
                Data = userResponseDto,
                Message = "User Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<UserResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public ReturnModel<UserResponseDto> Update(UserUpdateRequest updateRequest)
    {
        try
        {
            User? user = _mapper.Map<User>(updateRequest);
            _userRepository.Update(user);
            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);
            return new ReturnModel<UserResponseDto>()
            {
                Data = userResponseDto,
                Message = "User Güncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (NotFoundException ex)
        {
            return new ReturnModel<UserResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }
}
