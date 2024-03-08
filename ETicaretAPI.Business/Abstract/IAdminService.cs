using ETicaretAPI.Business.Dto.Request;
using ETicaretAPI.Business.Dto.Response;
using ETicaretAPI.Business.ReturnModels;

namespace ETicaretAPI.Business.Abstract;
public interface IAdminService
{
    ReturnModel<AdminResponseDto> Add(AdminCreateRequest adminCreateRequest);
    ReturnModel<AdminResponseDto> Update(AdminUpdateRequest adminUpdateRequest);
    ReturnModel<AdminResponseDto> Delete(int id);
    ReturnModel<List<AdminResponseDto>> GetAll();
    ReturnModel<AdminResponseDto> GetById(int id);
}
