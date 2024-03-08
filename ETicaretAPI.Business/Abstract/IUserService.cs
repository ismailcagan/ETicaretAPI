using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;

namespace ETicaretAPI.Business.Abstract;
public interface IUserService
{
    ReturnModel<UserResponseDto> Add(UserCreateRequest createRequest);
    ReturnModel<UserResponseDto> Update(UserUpdateRequest updateRequest);
    ReturnModel<UserResponseDto> Delete(int id);
    ReturnModel<List<UserResponseDto>> GetAll();
    ReturnModel<UserResponseDto> GetById(int id);
}
